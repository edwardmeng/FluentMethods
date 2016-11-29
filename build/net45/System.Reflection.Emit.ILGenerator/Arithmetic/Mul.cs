using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Mul<T>(this ILGenerator il, T value) => il.LoadConst(value).Mul();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and multiples them together
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Mul(this ILGenerator il) => il.FluentEmit(OpCodes.Mul);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, char value) => il.Mul<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, byte value) => il.Mul<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, sbyte value) => il.Mul<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, short value) => il.Mul<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, ushort value) => il.Mul<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, int value) => il.Mul<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, uint value) => il.Mul<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, long value) => il.Mul<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, ulong value) => il.Mul<ulong>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, float value) => il.Mul<float>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Mul with the evaluation stack value</param>
    public static ILGenerator Mul(this ILGenerator il, double value) => il.Mul<double>(value);
}