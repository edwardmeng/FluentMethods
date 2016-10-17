using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified module.
    /// </summary>
    /// <param name="module">The module to inspect.</param>
    /// <returns>A collection of the custom attributes that are applied to <paramref name="module"/>, or an empty collection if no such attributes exist.</returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this Module module)
    {
        return Attribute.GetCustomAttributes(module);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified module.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="module">The module to inspect.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="module"/> and that match <typeparamref name="T"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this Module module) where T : Attribute
    {
        return (IEnumerable<T>)module.GetCustomAttributes(typeof(T));
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified module.
    /// </summary>
    /// <param name="module">The module to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="module"/> and that match <paramref name="attributeType"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this Module module, Type attributeType)
    {
        return Attribute.GetCustomAttributes(module, attributeType);
    }
}