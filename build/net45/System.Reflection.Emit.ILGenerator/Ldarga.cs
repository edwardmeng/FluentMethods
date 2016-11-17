using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Load an argument address onto the evaluation stack.
    /// </summary>
    public static ILGenerator Ldarga(this ILGenerator il, int index)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldarga, index);
        return il;
    }
}