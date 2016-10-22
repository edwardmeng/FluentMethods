using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="provider">The provider to inspect.</param>
    /// <returns>A custom attribute that matches <typeparamref name="T"/>, or null if no such attribute is found.</returns>
    public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider) where T : Attribute
    {
        return (T)provider.GetCustomAttribute(typeof(T));
    }

    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The provider to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns>A custom attribute that matches <paramref name="attributeType"/>, or null if no such attribute is found.</returns>
    public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, Type attributeType)
    {
        if (provider == null)
        {
            throw new ArgumentNullException(nameof(provider));
        }
        if (attributeType == null)
        {
            throw new ArgumentNullException(nameof(attributeType));
        }
        var attributes = (Attribute[])provider.GetCustomAttributes(attributeType, true);
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