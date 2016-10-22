using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified parameter, and optionally inspects the ancestors of that parameter.
    /// </summary>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns>A custom attribute that matches <paramref name="attributeType"/>, or null if no such attribute is found.</returns>
    public static Attribute GetCustomAttribute(this ParameterInfo parameter, Type attributeType, bool inherit)
    {
        return Attribute.GetCustomAttribute(parameter, attributeType, inherit);
    }

    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified parameter, and optionally inspects the ancestors of that parameter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="parameter"/>; otherwise, <c>false</c>.</param>
    /// <returns>A custom attribute that matches <typeparamref name="T"/>, or null if no such attribute is found.</returns>
    public static T GetCustomAttribute<T>(this ParameterInfo parameter, bool inherit) where T : Attribute
    {
        return (T)parameter.GetCustomAttribute(typeof(T), inherit);
    }
}