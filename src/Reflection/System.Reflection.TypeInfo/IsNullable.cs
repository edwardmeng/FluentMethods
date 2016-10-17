using System;
using System.Reflection;

public static partial class Extensions
{
    public static bool IsNullable(this TypeInfo type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        return type.IsGenericType && !type.IsGenericTypeDefinition && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
}