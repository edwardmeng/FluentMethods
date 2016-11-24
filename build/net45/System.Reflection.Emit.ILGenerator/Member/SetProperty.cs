using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference and a value off the evaluation stack and calls the setter of the given property on the object with
    ///     the value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (!property.CanWrite)
            throw new InvalidOperationException("Cannot write to this property");
        return il.Call(property.GetSetMethod());
    }

    /// <summary>
    ///     Pops a reference and a value off the evaluation stack and calls the setter of the given property (looked up by name
    ///     on the given type) on the object with the value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName)
        => il.SetProperty(GetPropertyInfo(type, propertyName));

    /// <summary>
    ///     Pops a reference and a value off the evaluation stack and calls the setter of the given property (looked up by name
    ///     on the given type) on the object with the value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName)
        => il.SetProperty(typeof(T), propertyName);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression)
        => il.SetProperty(GetPropertyInfo(expression));

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, bool value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(bool))
            throw new InvalidOperationException("Property is not of type Boolean");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, bool value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, bool value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<bool>> expression, bool value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, bool value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, char value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(char))
            throw new InvalidOperationException("Property is not of type Char");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, char value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, char value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<char>> expression, char value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, char value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, sbyte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(sbyte))
            throw new InvalidOperationException("Property is not of type SByte");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, sbyte value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, sbyte value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<sbyte>> expression, sbyte value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, sbyte value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, byte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(byte))
            throw new InvalidOperationException("Property is not of type Byte");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, byte value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, byte value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<byte>> expression, byte value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, byte value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, short value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(short))
            throw new InvalidOperationException("Property is not of type Int16");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, short value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, short value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<short>> expression, short value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, short value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, ushort value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(ushort))
            throw new InvalidOperationException("Property is not of type UInt16");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, ushort value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, ushort value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ushort>> expression, ushort value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, ushort value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, int value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(int))
            throw new InvalidOperationException("Property is not of type Int32");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, int value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, int value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<int>> expression, int value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, int value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, uint value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(uint))
            throw new InvalidOperationException("Property is not of type UInt32");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, uint value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, uint value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<uint>> expression, uint value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, uint value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, long value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(long))
            throw new InvalidOperationException("Property is not of type Int64");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, long value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, long value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<long>> expression, long value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, long value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, ulong value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(ulong))
            throw new InvalidOperationException("Property is not of type UInt64");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, ulong value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, ulong value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ulong>> expression, ulong value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, ulong value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, float value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(ulong))
            throw new InvalidOperationException("Property is not of type UInt64");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, float value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, float value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ulong>> expression, float value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, float value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, double value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(ulong))
            throw new InvalidOperationException("Property is not of type UInt64");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, double value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, double value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ulong>> expression, double value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, double value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, string value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(ulong))
            throw new InvalidOperationException("Property is not of type UInt64");
        return il.LoadConst(value).SetProperty(property);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, string value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, string value)
        => il.SetProperty(typeof(T), propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ulong>> expression, string value)
        => il.SetProperty(GetPropertyInfo(expression), value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, string value)
        => il.SetProperty(GetPropertyInfo(expression), value);
}