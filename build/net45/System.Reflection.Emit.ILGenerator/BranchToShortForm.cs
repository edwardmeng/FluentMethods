using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Branch unconditionally to the given label
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchToShortForm(this ILGenerator il, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Br_S, label);
        return il;
    }
}