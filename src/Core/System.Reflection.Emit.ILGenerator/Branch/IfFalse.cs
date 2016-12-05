using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops an integer value from the evaluation stack and branches to the given label if it interprets as false
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IfFalse(this BranchILGenerator il)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        return il.IL.FluentEmit(il.ShortForm ? OpCodes.Brfalse_S : OpCodes.Brfalse, il.Label);
    }
}