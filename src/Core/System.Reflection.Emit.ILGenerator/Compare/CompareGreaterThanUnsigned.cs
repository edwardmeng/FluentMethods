using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator il, char value) => il.Cgt_Un(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator il, byte value) => il.Cgt_Un(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator il, ushort value) => il.Cgt_Un(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator il, uint value) => il.Cgt_Un(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator il, ulong value) => il.Cgt_Un(value);
}