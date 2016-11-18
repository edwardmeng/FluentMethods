using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, char value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, int value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, uint value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, long value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, ulong value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, float value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator BranchIfLessThanShortForm(this ILGenerator il, double value, Label label)
    {
        return il.LoadConst(value).BranchIfLessShortForm(label);
    }
}