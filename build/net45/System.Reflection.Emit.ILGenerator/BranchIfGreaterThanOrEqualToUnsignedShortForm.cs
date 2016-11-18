using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, char value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, int value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, uint value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, long value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, ulong value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, float value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, with regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfGreaterThanOrEqualToUnsignedShortForm(this ILGenerator il, double value, Label label)
    {
        return il.LoadConst(value).BranchIfGreaterThanOrEqualUnsignedShortForm(label);
    }
}