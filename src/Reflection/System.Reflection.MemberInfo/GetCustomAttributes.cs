using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <returns>A collection of the custom attributes that are applied to <paramref name="member"/>, or an empty collection if no such attributes exist.</returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo member)
    {
        return Attribute.GetCustomAttributes(member);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified member.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="member">The member to inspect.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="member"/> and that match <typeparamref name="T"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo member) where T : Attribute
    {
        return (IEnumerable<T>)member.GetCustomAttributes(typeof(T));
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="member"/> and that match <paramref name="attributeType"/>, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo member, Type attributeType)
    {
        return Attribute.GetCustomAttributes(member, attributeType);
    }
}