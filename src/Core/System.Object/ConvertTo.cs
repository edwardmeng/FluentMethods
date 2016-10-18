using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentMethods;

public static partial class Extensions
{
    private static readonly ConcurrentDictionary<Tuple<Type, Type>, Func<ITypeDescriptorContext, object, object>> _convertersCache = new ConcurrentDictionary<Tuple<Type, Type>, Func<ITypeDescriptorContext, object, object>>();

    internal static object ConvertTo(this object value, Type type, ITypeDescriptorContext context)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        var destinationType = type;
        if (destinationType.IsByRef)
        {
            destinationType = destinationType.GetElementType();
        }
        if (value == null || (value is string && string.IsNullOrEmpty((string)value)))
        {
            if (destinationType == typeof(string)) return value;
            if (!destinationType.IsClass && Nullable.GetUnderlyingType(destinationType) == null)
                throw new InvalidOperationException(string.Format(Strings.CannotConvertNullToValueType, destinationType));
            return null;
        }
        if (destinationType.IsInstanceOfType(value)) return value;
        var sourceType = value.GetType();

        if (sourceType.IsArray && destinationType.IsArray)
        {
            return ConvertArray((Array)value, type);
        }
        var converter = _convertersCache.GetOrAdd(Tuple.Create(sourceType, destinationType),
            key => CreateConverterFromDestination(key.Item1, key.Item2) ??
                   CreateConverterFromSource(key.Item1, key.Item2) ??
                   CreateConverterFromReflection(key.Item1, key.Item2));
        if (converter != null) return converter(context, value);
        object enumValue;
        if (type.IsEnum && TryConvertToEnum(value, type, out enumValue))
        {
            return TryConvertToEnum(value, type, out enumValue);
        }
        if (typeof(IConvertible).IsAssignableFrom(sourceType) && typeof(IConvertible).IsAssignableFrom(destinationType))
        {
            return Convert.ChangeType(value, destinationType);
        }
        throw CreateCannotConvertException(value, sourceType, destinationType, context);
    }

    public static object ConvertTo(this object value, Type type)
    {
        return value.ConvertTo(type, null);
    }

    public static T ConvertTo<T>(this object value)
    {
        return (T)value.ConvertTo(typeof(T));
    }

    private static Exception CreateCannotConvertException(object value, Type sourceType, Type destinationType, ITypeDescriptorContext context)
    {
        string sourceString;
        if (value is string)
        {
            sourceString = "\"" + value.ToString().Replace("\"", "\\\"") + "\"";
        }
        else if (value is char)
        {
            sourceString = "'" + value + "'";
        }
        else if (sourceType.GetMethod("ToString", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly, null, Type.EmptyTypes, null) != null)
        {
            sourceString = value + "(" + sourceType.FullName + ")";
        }
        else
        {
            sourceString = sourceType.FullName;
        }
        var property = context?.PropertyDescriptor;
        if (property != null)
        {
            return new InvalidOperationException(string.Format(Strings.CannotConvertPropertyValue, sourceString, destinationType, property.Name, property.ComponentType));
        }
        return new InvalidOperationException(string.Format(Strings.CannotConvertValue, sourceString, destinationType));
    }

    private static Array ConvertArray(Array sourceArray, Type destinationType)
    {
        var lengths = new int[sourceArray.Rank];
        var lowerBounds = new int[sourceArray.Rank];
        for (int i = 0; i < sourceArray.Rank; i++)
        {
            lengths[i] = sourceArray.GetLength(i);
            lowerBounds[i] = sourceArray.GetLowerBound(i);
        }
        var elementType = destinationType.GetElementType();
        var destinationArray = Array.CreateInstance(elementType, lengths, lowerBounds);
        sourceArray.Traverse((element, indices) => destinationArray.SetValue(element.ConvertTo(elementType), indices));
        return destinationArray;
    }

    private static bool TryConvertToEnum(object value, Type destinationType, out object result)
    {
        result = null;
        if (value is bool || value is char || value is short || value is int || value is long || value is byte || value is ushort || value is uint || value is ulong || value is sbyte)
        {
            result = Enum.ToObject(destinationType, value);
            return true;
        }
        if (value is double || value is decimal || value is float || value is Enum)
        {
            result = Enum.ToObject(destinationType, Convert.ChangeType(value, Enum.GetUnderlyingType(destinationType)));
            return true;
        }
        var text = value as string;
        if (text == null) return false;
        try
        {
            result = Enum.Parse(destinationType, text, false);
            return true;
        }
        catch (ArgumentException)
        {
        }
        try
        {
            result = Enum.Parse(destinationType, text, true);
            return true;
        }
        catch (ArgumentException)
        {
        }
        try
        {
            result = Enum.ToObject(destinationType, Convert.ChangeType(value, Enum.GetUnderlyingType(destinationType)));
            return true;
        }
        catch (ArgumentException)
        {
        }
        catch (FormatException)
        {
        }
        catch (OverflowException)
        {
        }
        return false;
    }

    private static Func<ITypeDescriptorContext, object, object> CreateConverterFromDestination(Type sourceType, Type destinationType)
    {
        var convertMethods = destinationType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(m => m.GetParameters().Length == 1 && m.ReturnType == destinationType).ToArray();
        var method =
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && m.GetParameters()[0].ParameterType == sourceType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && m.GetParameters()[0].ParameterType.IsAssignableFrom(sourceType)) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && m.GetParameters()[0].ParameterType == sourceType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && m.GetParameters()[0].ParameterType.IsAssignableFrom(sourceType));

        if (method == null) return null;
        var parameter = Expression.Parameter(typeof(object));
        var parameterType = method.GetParameters()[0].ParameterType;
        var converter = Expression.Lambda<Func<object, object>>(Expression.TypeAs(
            Expression.Call(method, parameterType.IsValueType
                ? Expression.Convert(parameter, parameterType)
                : Expression.TypeAs(parameter, parameterType)), typeof(object)), parameter).Compile();
        return (context, value) => converter(value);
    }

    private static Func<ITypeDescriptorContext, object, object> CreateConverterFromSource(Type sourceType, Type destinationType)
    {
        var convertMethods = sourceType.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m =>
        {
            var parameters = m.GetParameters();
            return parameters.Length == 1 && parameters[0].ParameterType == sourceType;
        }).ToArray();
        var method =
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && m.ReturnType == destinationType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && destinationType.IsAssignableFrom(m.ReturnType)) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && m.ReturnType == destinationType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && destinationType.IsAssignableFrom(m.ReturnType));
        if (method == null) return null;
        var parameter = Expression.Parameter(typeof(object));
        var converter = Expression.Lambda<Func<object, object>>(Expression.TypeAs(Expression.Call(method, sourceType.IsValueType
            ? Expression.Convert(parameter, sourceType)
            : Expression.TypeAs(parameter, sourceType)), typeof(object)), parameter).Compile();
        return (context, value) => converter(value);
    }

    private static Func<ITypeDescriptorContext, object, object> CreateConverterFromReflection(Type sourceType, Type destinationType)
    {
        var sourceConverter = TypeDescriptor.GetConverter(sourceType);
        if (sourceConverter.CanConvertTo(destinationType))
        {
            return (context, value) => sourceConverter.ConvertTo(context, CultureInfo.CurrentCulture, value, destinationType);
        }
        var targetConverter = TypeDescriptor.GetConverter(destinationType);
        if (targetConverter.CanConvertFrom(sourceType))
        {
            return (context, value) => targetConverter.ConvertFrom(context, CultureInfo.CurrentCulture, value);
        }
        return null;
    }
}