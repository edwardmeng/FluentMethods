using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pushes a supplied value of type float32 onto the evaluation stack as type F (float).
    /// </summary>
    public static ILGenerator Ldc_R4(this ILGenerator il, float value)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldc_R4, value);
        return il;
    }
}