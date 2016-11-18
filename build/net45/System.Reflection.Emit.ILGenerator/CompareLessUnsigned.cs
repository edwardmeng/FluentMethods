using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and pushes the result of comparing whether the first is less than
    ///     the second, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator CompareLessUnsigned(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Clt_Un);
        return il;
    }
}