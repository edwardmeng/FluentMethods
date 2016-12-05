using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Branch unconditionally to the given label
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Unconditionally(this BranchILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.IL.FluentEmit(il.ShortForm ? OpCodes.Br : OpCodes.Br_S, il.Label);
    }
}