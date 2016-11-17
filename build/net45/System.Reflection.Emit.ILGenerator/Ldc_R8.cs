using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pushes a supplied value of type float64 onto the evaluation stack as type F (float).
    /// </summary>
    public static ILGenerator Ldc_R8(this ILGenerator il, double value)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldc_R8, value);
        return il;
    }
}