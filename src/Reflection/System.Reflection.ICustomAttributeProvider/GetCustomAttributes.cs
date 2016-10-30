using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified <see cref="ICustomAttributeProvider"/>, and optionally inspects the ancestors of that provider.
    /// </summary>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="provider"/>; otherwise, <c>false</c>.</param>
    /// <returns>A collection of the custom attributes that are applied to <paramref name="provider"/>, or an empty collection if no such attributes exist.</returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this ICustomAttributeProvider provider, bool inherit = true)
    {
        return (Attribute[])provider.GetCustomAttributes(inherit);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified <see cref="ICustomAttributeProvider"/>, and optionally inspects the ancestors of that provider.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="provider"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="provider"/> and that match <typeparamref name="T"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this ICustomAttributeProvider provider, bool inherit = true) where T : Attribute
    {
        return (IEnumerable<T>)provider.GetCustomAttributes(typeof(T), inherit);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified <see cref="ICustomAttributeProvider"/>, and optionally inspects the ancestors of that provider.
    /// </summary>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="provider"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="provider"/> and that match <paramref name="attributeType"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this ICustomAttributeProvider provider, Type attributeType, bool inherit = true)
    {
        return (Attribute[]) provider.GetCustomAttributes(attributeType, inherit);
    }
}