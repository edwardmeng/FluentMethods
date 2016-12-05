using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and branches to the given label if the first is less than the
    ///     second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IfLess(this BranchILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.IL.FluentEmit(il.ShortForm ? OpCodes.Blt_S : OpCodes.Blt, il.Label);
    }
}