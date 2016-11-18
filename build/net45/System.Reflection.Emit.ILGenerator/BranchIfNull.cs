using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops a reference from the evaluation stack and branches to the given label if it is the null reference
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfNull(this ILGenerator il, Label label)
    {
        return il.LoadNull().BranchIfEqual(label);
    }
}