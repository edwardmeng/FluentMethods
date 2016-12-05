using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and multiples them together without regard for sign, and a
    ///     check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il) => il.Mul_Ovf_Un();

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, char value) => il.Mul_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, byte value) => il.Mul_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, ushort value) => il.Mul_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, uint value) => il.Mul_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, ulong value) => il.Mul_Ovf_Un(value);
}