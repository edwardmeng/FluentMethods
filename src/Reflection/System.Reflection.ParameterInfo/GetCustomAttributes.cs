using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified parameter, and optionally inspects the ancestors of that parameter.
    /// </summary>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="parameter"/> that match the specified criteria, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo parameter, bool inherit)
    {
        return Attribute.GetCustomAttributes(parameter, inherit);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified parameter, and optionally inspects the ancestors of that parameter.
    /// </summary>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="parameter"/> that match the specified criteria, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo parameter, Type attributeType, bool inherit)
    {
        return Attribute.GetCustomAttributes(parameter, attributeType, inherit);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified parameter, and optionally inspects the ancestors of that parameter.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="parameter"/> that match the specified criteria, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo parameter, bool inherit) where T : Attribute
    {
        return (IEnumerable<T>)parameter.GetCustomAttributes(typeof(T), inherit);
    }

}