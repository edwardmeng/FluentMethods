using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentMethods;

public static partial class Extensions
{
#if Net35
    private sealed class Pair<TFirst, TSecond>
    {
        public TFirst First { get; }

        public TSecond Second { get; }

        public Pair(TFirst x, TSecond y)
        {
            First = x;
            Second = y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = System.Collections.Generic.EqualityComparer<TFirst>.Default.GetHashCode(First);
                return ((hashCode << 5) + hashCode) ^ System.Collections.Generic.EqualityComparer<TSecond>.Default.GetHashCode(Second);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Pair<TFirst, TSecond>;
            if (other == null) return false;
            return System.Collections.Generic.EqualityComparer<TFirst>.Default.Equals(First, other.First) && System.Collections.Generic.EqualityComparer<TSecond>.Default.Equals(Second, other.Second);
        }
    }

    private static readonly System.Collections.Generic.IDictionary<Pair<Type, Type>, Func<ITypeDescriptorContext, object, object>> _convertersCache = new System.Collections.Generic.Dictionary<Pair<Type, Type>, Func<ITypeDescriptorContext, object, object>>();

    private static Func<ITypeDescriptorContext, object, object> GetConverter(Type sourceType, Type destinationType)
    {
        var key = new Pair<Type,Type>(sourceType,destinationType);
        if (!_convertersCache.ContainsKey(key))
        {
            lock (_convertersCache)
            {
                if (!_convertersCache.ContainsKey(key))
                {
                    _convertersCache.Add(key, CreateConverterFromDestination(sourceType, destinationType) ??
                   CreateConverterFromSource(sourceType, destinationType) ??
                   CreateConverterFromReflection(sourceType, destinationType));
                }
            }
        }
        return _convertersCache[key];
    }
#else
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<Tuple<Type, Type>, Func<ITypeDescriptorContext, object, object>> _convertersCache = new System.Collections.Concurrent.ConcurrentDictionary<Tuple<Type, Type>, Func<ITypeDescriptorContext, object, object>>();

    private static Func<ITypeDescriptorContext, object, object> GetConverter(Type sourceType, Type destinationType)
    {
        return _convertersCache.GetOrAdd(Tuple.Create(sourceType, destinationType),
            key => CreateConverterFromDestination(key.Item1, key.Item2) ??
                   CreateConverterFromSource(key.Item1, key.Item2) ??
                   CreateConverterFromReflection(key.Item1, key.Item2));
    }
#endif

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
        var underlyingType = Nullable.GetUnderlyingType(destinationType);
        if (value == null ||
#if !NetCore
            Convert.IsDBNull(value) ||
#endif
            (value is string && string.IsNullOrEmpty((string)value)))
        {
            if (destinationType == typeof(string)) return value;
            bool isClass;
#if NetCore
            isClass = destinationType.GetTypeInfo().IsClass;
#else
            isClass = destinationType.IsClass;
#endif
            if (!isClass && underlyingType == null)
                throw new InvalidOperationException(string.Format(Strings.CannotConvertNullToValueType, destinationType));
            return null;
        }
#if NetCore
        if (destinationType.GetTypeInfo().IsInstanceOfType(value)) return value;
#else
        if (destinationType.IsInstanceOfType(value)) return value;
#endif
        var sourceType = value.GetType();

        if (sourceType.IsArray && destinationType.IsArray)
        {
            return ConvertArray((Array)value, type);
        }
        var converter = GetConverter(sourceType, destinationType);
        if (converter != null) return converter(context, value);
        if (underlyingType!=null) destinationType = underlyingType;
        object enumValue;
#if NetCore
        if (destinationType.GetTypeInfo().IsEnum && TryConvertToEnum(value, destinationType, out enumValue))
        {
            return enumValue;
        }
        if (typeof(IConvertible).GetTypeInfo().IsAssignableFrom(sourceType) && typeof(IConvertible).GetTypeInfo().IsAssignableFrom(destinationType))
        {
            return Convert.ChangeType(value, destinationType);
        }
#else
        if (destinationType.IsEnum && TryConvertToEnum(value, destinationType, out enumValue))
        {
            return enumValue;
        }
        if (typeof(IConvertible).IsAssignableFrom(sourceType) && typeof(IConvertible).IsAssignableFrom(destinationType))
        {
            return Convert.ChangeType(value, destinationType);
        }
#endif
        throw CreateCannotConvertException(value, sourceType, type, context);
    }

    /// <summary>
    /// Converts value to the specified type.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="type">The type to convert to.</param>
    /// <returns>The converted value of the target type.</returns>
    public static object ConvertTo(this object value, Type type)
    {
        return value.ConvertTo(type, null);
    }

    /// <summary>
    /// Converts value to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert to.</typeparam>
    /// <param name="value">The value to be converted.</param>
    /// <returns>The converted value of the target type.</returns>
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
#if NetCore
        else if (sourceType.GetTypeInfo().GetDeclaredMethods("ToString").Any(method => !method.IsStatic && method.IsPublic && method.GetParameters().Length == 0))
#else
        else if (sourceType.GetMethod("ToString", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly, null, Type.EmptyTypes, null) != null)
#endif
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

#if NetCore
    private static Func<ITypeDescriptorContext, object, object> CreateConverterFromDestination(Type sourceType, Type destinationType)
    {
        var convertMethods = destinationType.GetTypeInfo().GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(m => m.GetParameters().Length == 1 && m.ReturnType == destinationType).ToArray();
        var method =
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && m.GetParameters()[0].ParameterType == sourceType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && m.GetParameters()[0].ParameterType.GetTypeInfo().IsAssignableFrom(sourceType)) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && m.GetParameters()[0].ParameterType == sourceType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && m.GetParameters()[0].ParameterType.GetTypeInfo().IsAssignableFrom(sourceType));

        if (method == null) return null;
        var parameter = Expression.Parameter(typeof(object), "source");
        var parameterType = method.GetParameters()[0].ParameterType;
        var cast = parameterType.GetTypeInfo().IsValueType ? Expression.Convert(parameter, parameterType) : Expression.TypeAs(parameter, parameterType);
        var converter = Expression.Lambda<Func<object, object>>(Expression.TypeAs(
            Expression.Call(method, cast), typeof(object)), parameter).Compile();
        return (context, value) => converter(value);
    }

    private static Func<ITypeDescriptorContext, object, object> CreateConverterFromSource(Type sourceType, Type destinationType)
    {
        var convertMethods = sourceType.GetTypeInfo().GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m =>
        {
            var parameters = m.GetParameters();
            return parameters.Length == 1 && parameters[0].ParameterType == sourceType;
        }).ToArray();
        var method =
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && m.ReturnType == destinationType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Implicit" && destinationType.GetTypeInfo().IsAssignableFrom(m.ReturnType)) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && m.ReturnType == destinationType) ??
            convertMethods.FirstOrDefault(m => m.Name == "op_Explicit" && destinationType.GetTypeInfo().IsAssignableFrom(m.ReturnType));
        if (method == null) return null;
        var parameter = Expression.Parameter(typeof(object), "source");
        var converter = Expression.Lambda<Func<object, object>>(Expression.TypeAs(Expression.Call(method, sourceType.GetTypeInfo().IsValueType
            ? Expression.Convert(parameter, sourceType)
            : Expression.TypeAs(parameter, sourceType)), typeof(object)), parameter).Compile();
        return (context, value) => converter(value);
    }
#else
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
        var parameter = Expression.Parameter(typeof(object), "source");
        var parameterType = method.GetParameters()[0].ParameterType;
        var cast = parameterType.IsValueType ? Expression.Convert(parameter, parameterType) : Expression.TypeAs(parameter, parameterType);
        var converter = Expression.Lambda<Func<object, object>>(Expression.TypeAs(
            Expression.Call(method, cast), typeof(object)), parameter).Compile();
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
        var parameter = Expression.Parameter(typeof(object), "source");
        var converter = Expression.Lambda<Func<object, object>>(Expression.TypeAs(Expression.Call(method, sourceType.IsValueType
            ? Expression.Convert(parameter, sourceType)
            : Expression.TypeAs(parameter, sourceType)), typeof(object)), parameter).Compile();
        return (context, value) => converter(value);
    }
#endif

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