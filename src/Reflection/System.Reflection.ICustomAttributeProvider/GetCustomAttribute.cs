using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified <see cref="ICustomAttributeProvider"/>, and optionally inspects the ancestors of that provider.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="provider"/>; otherwise, <c>false</c>.</param>
    /// <returns>A custom attribute that matches <typeparamref name="T"/>, or null if no such attribute is found.</returns>
    public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider, bool inherit = true) where T : Attribute
    {
        return (T)provider.GetCustomAttribute(typeof(T), inherit);
    }

    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified <see cref="ICustomAttributeProvider"/>, and optionally inspects the ancestors of that provider.
    /// </summary>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="provider"/>; otherwise, <c>false</c>.</param>
    /// <returns>A custom attribute that matches <paramref name="attributeType"/>, or null if no such attribute is found.</returns>
    public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, Type attributeType, bool inherit = true)
    {
        if (provider == null)
        {
            throw new ArgumentNullException(nameof(provider));
        }
        if (attributeType == null)
        {
            throw new ArgumentNullException(nameof(attributeType));
        }
        var attributes = (Attribute[])provider.GetCustomAttributes(attributeType, inherit);
        if (attributes.Length == 0)
        {
            return null;
        }
        if (attributes.Length != 1)
        {
            throw new AmbiguousMatchException("Multiple custom attributes of the same type found.");
        }
        return attributes[0];
    }
}