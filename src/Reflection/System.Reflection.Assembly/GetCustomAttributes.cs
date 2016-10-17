using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <returns>A collection of the custom attributes that are applied to <paramref name="assembly"/>, or an empty collection if no such attributes exist.</returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this Assembly assembly)
    {
        return Attribute.GetCustomAttributes(assembly);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified assembly.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="assembly"/> and that match <typeparamref name="T"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this Assembly assembly) where T : Attribute
    {
        return (IEnumerable<T>)assembly.GetCustomAttributes(typeof(T));
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="assembly"/> and that match <paramref name="attributeType"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this Assembly assembly, Type attributeType)
    {
        return Attribute.GetCustomAttributes(assembly, attributeType);
    }
}