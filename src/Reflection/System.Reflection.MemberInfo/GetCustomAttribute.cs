using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified member, and optionally inspects the ancestors of that member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="member"/>; otherwise, <c>false</c>.</param>
    /// <returns>A custom attribute that matches <paramref name="attributeType"/>, or null if no such attribute is found.</returns>
    public static Attribute GetCustomAttribute(this MemberInfo member, Type attributeType, bool inherit)
    {
        return Attribute.GetCustomAttribute(member, attributeType, inherit);
    }

    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to a specified member, and optionally inspects the ancestors of that member.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="member">The member to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="member"/>; otherwise, <c>false</c>.</param>
    /// <returns>A custom attribute that matches <typeparamref name="T"/>, or null if no such attribute is found.</returns>
    public static T GetCustomAttribute<T>(this MemberInfo member, bool inherit) where T : Attribute
    {
        return (T)member.GetCustomAttribute(typeof(T), inherit);
    }
}