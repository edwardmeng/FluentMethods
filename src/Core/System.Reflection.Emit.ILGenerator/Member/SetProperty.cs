using FluentMethods;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator SetProperty<T>(this ILGenerator il, PropertyInfo property, T value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (property.PropertyType != typeof(T))
            throw new InvalidOperationException(string.Format(Strings.PropertyTypeNotMatch, property.Name, property.DeclaringType?.FullName, typeof(T).FullName));
        return il.Ldc(value).SetProperty(property);
    }

    private static ILGenerator SetProperty<T>(this ILGenerator il, Type type, string propertyName, T value)
        => il.SetProperty(GetPropertyInfo(type, propertyName), value);

    private static ILGenerator SetProperty<T, TProp>(this ILGenerator il, string propertyName, TProp value)
        => il.SetProperty(typeof(T), propertyName, value);

    private static ILGenerator SetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression, TProp value)
    => il.SetProperty(GetPropertyInfo(expression), value);

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
            throw new InvalidOperationException(string.Format(Strings.CannotWriteProperty, property.Name, property.DeclaringType?.FullName));
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
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T>> expression, T value)
        => il.SetProperty(GetPropertyInfo(expression), value);

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
        => il.SetProperty<bool>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, bool value)
        => il.SetProperty<bool>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, bool value)
        => il.SetProperty<T, bool>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<bool>> expression, bool value)
        => il.SetProperty<bool>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, bool>> expression, bool value)
        => il.SetProperty<T, bool>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, char value)
        => il.SetProperty<char>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, char value)
        => il.SetProperty<char>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, char value)
        => il.SetProperty<T, char>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<char>> expression, char value)
        => il.SetProperty<char>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, char>> expression, char value)
        => il.SetProperty<T, char>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, sbyte value)
        => il.SetProperty<sbyte>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, sbyte value)
        => il.SetProperty<sbyte>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, sbyte value)
        => il.SetProperty<T, sbyte>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<sbyte>> expression, sbyte value)
        => il.SetProperty<sbyte>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, sbyte>> expression, sbyte value)
        => il.SetProperty<T, sbyte>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, byte value)
        => il.SetProperty<byte>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, byte value)
        => il.SetProperty<byte>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, byte value)
        => il.SetProperty<T, byte>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<byte>> expression, byte value)
        => il.SetProperty<byte>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, byte>> expression, byte value)
        => il.SetProperty<T, byte>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, short value)
        => il.SetProperty<short>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, short value)
        => il.SetProperty<short>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, short value)
        => il.SetProperty<T, short>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<short>> expression, short value)
        => il.SetProperty<short>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, short>> expression, short value)
        => il.SetProperty<T, short>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, ushort value)
        => il.SetProperty<ushort>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, ushort value)
        => il.SetProperty<ushort>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, ushort value)
        => il.SetProperty<T, ushort>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ushort>> expression, ushort value)
        => il.SetProperty<ushort>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, ushort>> expression, ushort value)
        => il.SetProperty<T, ushort>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, int value)
        => il.SetProperty<int>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, int value)
        => il.SetProperty<int>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, int value)
        => il.SetProperty<T, int>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<int>> expression, int value)
        => il.SetProperty<int>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, int>> expression, int value)
        => il.SetProperty<T, int>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, uint value)
        => il.SetProperty<uint>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, uint value)
        => il.SetProperty<uint>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, uint value)
        => il.SetProperty<T, uint>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<uint>> expression, uint value)
        => il.SetProperty<uint>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, uint>> expression, uint value)
        => il.SetProperty<T, uint>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, long value)
        => il.SetProperty<long>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, long value)
        => il.SetProperty<long>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, long value)
        => il.SetProperty<T, long>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<long>> expression, long value)
        => il.SetProperty<long>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, long>> expression, long value)
        => il.SetProperty<T, long>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, ulong value)
        => il.SetProperty<ulong>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, ulong value)
        => il.SetProperty<ulong>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, ulong value)
        => il.SetProperty<T, ulong>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<ulong>> expression, ulong value)
        => il.SetProperty<ulong>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, ulong>> expression, ulong value)
        => il.SetProperty<T, ulong>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, float value)
        => il.SetProperty<float>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, float value)
        => il.SetProperty<float>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, float value)
        => il.SetProperty<T, float>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<float>> expression, float value)
        => il.SetProperty<float>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, float>> expression, float value)
        => il.SetProperty<T,float>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, double value)
        => il.SetProperty<double>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, double value)
        => il.SetProperty<double>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, double value)
        => il.SetProperty<T,double>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<double>> expression, double value)
        => il.SetProperty<double>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, double>> expression, double value)
        => il.SetProperty<T, double>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, decimal value)
        => il.SetProperty<decimal>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, decimal value)
        => il.SetProperty<decimal>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, decimal value)
        => il.SetProperty<T, decimal>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<decimal>> expression, decimal value)
        => il.SetProperty<decimal>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, decimal>> expression, decimal value)
        => il.SetProperty<T, decimal>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object with the given
    ///     value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to set</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, PropertyInfo property, string value)
        => il.SetProperty<string>(property, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Type type, string propertyName, string value)
        => il.SetProperty<string>(type, propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, string propertyName, string value)
        => il.SetProperty<T,string>(propertyName, value);

    /// <summary>
    ///     Calls the setter of the static property represented by the given expression with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, Expression<Func<string>> expression, string value)
        => il.SetProperty<string>(expression, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty<T>(this ILGenerator il, Expression<Func<T, string>> expression, string value)
        => il.SetProperty<T, string>(expression, value);

#if Net45 || NetCore

    /// <summary>
    ///     Pops a reference and a value off the evaluation stack and calls the setter of the given property (looked up by name
    ///     on the given type) on the object with the value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName)
        => il.SetProperty(type?.AsType(), propertyName);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, bool value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, char value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, sbyte value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, byte value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, short value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, ushort value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, int value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, uint value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, long value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, ulong value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, float value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, double value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, decimal value)
        => il.SetProperty(type?.AsType(), propertyName, value);

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the setter of the given property (looked up by name on the
    ///     given type) on the object with the given value
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    /// <param name="value">The value to set the property to</param>
    public static ILGenerator SetProperty(this ILGenerator il, TypeInfo type, string propertyName, string value)
        => il.SetProperty(type?.AsType(), propertyName, value);
#endif
}