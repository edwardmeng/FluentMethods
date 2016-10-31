using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether a specified type can be null.
    /// </summary>
    /// <param name="type">The type to inspect.</param>
    /// <returns><c>true</c> if the specified type can be null; otherwise, <c>false</c>.</returns>
    public static bool IsNullable(this TypeInfo type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        return !type.IsValueType || (type.IsGenericType && !type.IsGenericTypeDefinition && type.GetGenericTypeDefinition() == typeof(Nullable<>));
    }
}