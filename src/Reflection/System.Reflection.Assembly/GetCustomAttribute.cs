using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified assembly.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <returns>A custom attribute that matches <typeparamref name="T"/>, or null if no such attribute is found.</returns>
    public static T GetCustomAttribute<T>(this Assembly assembly) where T : Attribute
    {
        return (T)assembly.GetCustomAttribute(typeof(T));
    }

    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns>A custom attribute that matches <paramref name="attributeType"/>, or null if no such attribute is found.</returns>
    public static Attribute GetCustomAttribute(this Assembly assembly, Type attributeType)
    {
        return Attribute.GetCustomAttribute(assembly, attributeType);
    }
}