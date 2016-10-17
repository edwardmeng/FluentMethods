using System;

public static partial class Extensions
{
    public static bool IsNullable(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        return Nullable.GetUnderlyingType(type) != null;
    }
}