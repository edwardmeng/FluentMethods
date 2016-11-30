using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Mul_Ovf<T>(this ILGenerator il, T value) => il.Ldc(value).Mul_Ovf();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and multiples them together with a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il) => il.FluentEmit(OpCodes.Mul_Ovf);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, char value) => il.Mul_Ovf<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, byte value) => il.Mul_Ovf<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, sbyte value) => il.Mul_Ovf<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, short value) => il.Mul_Ovf<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, ushort value) => il.Mul_Ovf<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, int value) => il.Mul_Ovf<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, uint value) => il.Mul_Ovf<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, long value) => il.Mul_Ovf<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Mul_Ovf(this ILGenerator il, ulong value) => il.Mul_Ovf<ulong>(value);
}