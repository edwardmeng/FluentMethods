using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops an integer value from the evaluation stack and branches to the given label if it interprets as true
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IfTrue(this BranchILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.IL.Emit(il.ShortForm ? OpCodes.Brtrue_S : OpCodes.Brtrue, il.Label);
        return il.IL;
    }
}