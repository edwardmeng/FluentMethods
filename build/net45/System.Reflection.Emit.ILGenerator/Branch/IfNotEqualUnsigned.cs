using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and branches to the given label if the first is not equal to the
    ///     second, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IfNotEqualUnsigned(this BranchILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.IL.Emit(il.ShortForm ? OpCodes.Bne_Un_S : OpCodes.Bne_Un, il.Label);
        return il.IL;
    }
}