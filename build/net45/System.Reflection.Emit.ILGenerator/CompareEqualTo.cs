using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, char value)
    {
        return il.LoadConst(value).CompareEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, int value)
    {
        return il.LoadConst(value).CompareEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).CompareEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, long value)
    {
        return il.LoadConst(value).CompareEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).CompareEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, float value)
    {
        return il.LoadConst(value).CompareEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is equal to the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareEqualTo(this ILGenerator il, double value)
    {
        return il.LoadConst(value).CompareEqual();
    }
}