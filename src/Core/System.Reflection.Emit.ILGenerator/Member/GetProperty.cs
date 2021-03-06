﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using FluentMethods;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the getter of the given property on the object
    /// </summary>
    /// <param name="il"></param>
    /// <param name="property">The property to get the value of</param>
    public static ILGenerator GetProperty(this ILGenerator il, PropertyInfo property)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        if (!property.CanRead)
            throw new InvalidOperationException(string.Format(Strings.CannotReadProperty, property.Name, property.DeclaringType?.FullName));
        var method = property.GetGetMethod();
        return il.Call(method);
    }

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the getter of the given property (looked up by name on the
    ///     given type) on the object
    /// </summary>
    /// <remarks>Will only consider public properties, static or instance</remarks>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    public static ILGenerator GetProperty(this ILGenerator il, Type type, string propertyName)
        => il.GetProperty(GetPropertyInfo(type, propertyName));

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the getter of the given property (looked up by name on the
    ///     given type) on the object
    /// </summary>
    /// <remarks>Will only consider public properties, static or instance</remarks>
    /// <param name="il"></param>
    /// <param name="type">The type the property belongs to</param>
    /// <param name="propertyName">The name of the property on the given <paramref name="type" /></param>
    public static ILGenerator GetProperty(this ILGenerator il, TypeInfo type, string propertyName)
    {
        return il.GetProperty(type?.AsType(), propertyName);
    }
#endif

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the getter of the given property (looked up by name on the
    ///     given type) on the object
    /// </summary>
    /// <remarks>Will only consider public properties, static or instance</remarks>
    /// <typeparam name="T">The type the property belongs to</typeparam>
    /// <param name="il"></param>
    /// <param name="propertyName">The name of the property on <typeparamref name="T" /></param>
    public static ILGenerator GetProperty<T>(this ILGenerator il, string propertyName)
        => il.GetProperty(typeof(T), propertyName);

    /// <summary>
    ///     Calls the getter of the static property represented by the given expression and pushes the value onto the
    ///     evaluatino stack
    /// </summary>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    public static ILGenerator GetProperty<TProp>(this ILGenerator il, Expression<Func<TProp>> expression)
        => il.GetProperty(GetPropertyInfo(expression));

    /// <summary>
    ///     Pops a reference off the evaluation stack and calls the getter of the given property on the object
    /// </summary>
    /// <typeparam name="T">The type the property is on</typeparam>
    /// <typeparam name="TProp">The type of the property</typeparam>
    /// <param name="il"></param>
    /// <param name="expression">An expression that accesses the relevant property</param>
    public static ILGenerator GetProperty<T, TProp>(this ILGenerator il, Expression<Func<T, TProp>> expression)
        => il.GetProperty(GetPropertyInfo(expression));

    private static PropertyInfo GetPropertyInfo(Type type, string propertyName)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        var property = type.GetTypeInfo().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
#else
        var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
#endif
        if (property == null)
            throw new InvalidOperationException(string.Format(Strings.NoProperty, propertyName, type.FullName));
        return property;
    }

    private static PropertyInfo GetPropertyInfo(LambdaExpression expression)
    {
        if (expression == null)
            throw new ArgumentNullException(nameof(expression));
        var property = (expression.Body as MemberExpression)?.Member as PropertyInfo;

        if (property == null)
            throw new ArgumentException(Strings.NotPropertyExpression, nameof(expression));

        return property;
    }
}