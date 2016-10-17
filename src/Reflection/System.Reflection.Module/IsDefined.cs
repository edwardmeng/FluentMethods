using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified module.
    /// </summary>
    /// <param name="module">The module to inspect.</param>
    /// <param name="attributeType">The type of the attribute to search for.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="module"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined(this Module module, Type attributeType)
    {
        return Attribute.IsDefined(module, attributeType);
    }

    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified module.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to search for.</typeparam>
    /// <param name="module">The module to inspect.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="module"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined<T>(this Module module)
    {
        return module.IsDefined(typeof(T));
    }
}