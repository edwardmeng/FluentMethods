using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified member, and, optionally, applied to its ancestors.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to search for.</typeparam>
    /// <param name="member">The member to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="member"/>; otherwise, <c>false</c>.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="member"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined<T>(this MemberInfo member, bool inherit)
    {
        return member.IsDefined(typeof(T), inherit);
    }
}