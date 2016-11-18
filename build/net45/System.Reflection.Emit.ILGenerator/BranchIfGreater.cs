using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and branches to the given label if the first is greater than the
    ///     second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreater(this ILGenerator il, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Bgt, label);
        return il;
    }
}