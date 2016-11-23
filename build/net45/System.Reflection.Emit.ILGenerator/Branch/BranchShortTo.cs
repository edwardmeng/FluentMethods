using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Create a new instance of <see cref="BranchILGenerator"/> that represents the branch clause.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static BranchILGenerator BranchShortTo(this ILGenerator il, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return new BranchILGenerator(il, label, true);
    }
}