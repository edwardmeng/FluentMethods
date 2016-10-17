using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <param name="attributeType">The type of the attribute to search for.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="assembly"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined(this Assembly assembly, Type attributeType)
    {
        return Attribute.IsDefined(assembly, attributeType);
    }

    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified assembly.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to search for.</typeparam>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="assembly"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined<T>(this Assembly assembly)
    {
        return assembly.IsDefined(typeof(T));
    }
}