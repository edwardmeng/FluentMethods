using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pushes a supplied value of type int64 onto the evaluation stack as an int64.
    /// </summary>
    public static ILGenerator Ldc_I8(this ILGenerator il, long value)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldc_I8, value);
        return il;
    }
}