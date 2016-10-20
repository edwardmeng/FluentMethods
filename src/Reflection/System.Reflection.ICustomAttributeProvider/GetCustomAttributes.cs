using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The provider to inspect.</param>
    /// <returns>A collection of the custom attributes that are applied to <paramref name="provider"/>, or an empty collection if no such attributes exist.</returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this ICustomAttributeProvider provider)
    {
        return (Attribute[])provider.GetCustomAttributes(true);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="provider">The provider to inspect.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="provider"/> and that match <typeparamref name="T"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this ICustomAttributeProvider provider) where T : Attribute
    {
        return (IEnumerable<T>)provider.GetCustomAttributes(typeof(T));
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="provider"/> and that match <paramref name="attributeType"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this ICustomAttributeProvider provider, Type attributeType)
    {
        return (Attribute[]) provider.GetCustomAttributes(attributeType, true);
    }
}