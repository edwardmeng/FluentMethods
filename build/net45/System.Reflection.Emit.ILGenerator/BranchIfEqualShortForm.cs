using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and branches to the given label if the first is equal to the
    ///     second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Beq_S, label);
        return il;
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, char value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, int value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, uint value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, long value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, ulong value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, float value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfEqualShortForm(this ILGenerator il, double value, Label label)
    {
        return il.LoadConst(value).BranchIfEqualShortForm(label);
    }
}