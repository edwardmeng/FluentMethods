using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified parameter.
    /// </summary>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="attributeType">The type of the attribute to search for.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="parameter"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined(this ParameterInfo parameter, Type attributeType)
    {
        return Attribute.IsDefined(parameter, attributeType);
    }

    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified parameter.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to search for.</typeparam>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="parameter"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined<T>(this ParameterInfo parameter)
    {
        return parameter.IsDefined(typeof(T));
    }

    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified parameter, and, optionally, applied to its ancestors.
    /// </summary>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="attributeType">The type of the attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="parameter"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined(this ParameterInfo parameter, Type attributeType, bool inherit)
    {
        return Attribute.IsDefined(parameter, attributeType, inherit);
    }

    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified parameter, and, optionally, applied to its ancestors.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to search for.</typeparam>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="parameter"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined<T>(this ParameterInfo parameter, bool inherit)
    {
        return parameter.IsDefined(typeof(T), inherit);
    }
}