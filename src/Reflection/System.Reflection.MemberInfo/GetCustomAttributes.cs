using System;
using System.Collections.Generic;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a collection of custom attributes that are applied to a specified member, and optionally inspects the ancestors of that member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="member"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="member"/> that match the specified criteria, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo member, bool inherit)
    {
        return Attribute.GetCustomAttributes(member, inherit);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified member, and optionally inspects the ancestors of that member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="member"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="member"/> that match the specified criteria, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo member, Type attributeType, bool inherit)
    {
        return Attribute.GetCustomAttributes(member, attributeType, inherit);
    }

    /// <summary>
    /// Retrieves a collection of custom attributes of a specified type that are applied to a specified member, and optionally inspects the ancestors of that member.
    /// </summary>
    /// <typeparam name="T">The type of attribute to search for.</typeparam>
    /// <param name="member">The member to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="member"/>; otherwise, <c>false</c>.</param>
    /// <returns>
    /// A collection of the custom attributes that are applied to <paramref name="member"/> that match the specified criteria, 
    /// or an empty collection if no such attributes exist.
    /// </returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo member, bool inherit) where T : Attribute
    {
        return (IEnumerable<T>)member.GetCustomAttributes(typeof(T), inherit);
    }

}