using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Converts the boxed representation of a value type to its unboxed form.
    /// </summary>
    public static ILGenerator Unbox(this ILGenerator il, Type type)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
        return il;
    }
}