using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops an integer value from the evaluation stack and branches to the given label if it interprets as false
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfFalseShortForm(this ILGenerator il, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Brfalse_S, label);
        return il;
    }
}