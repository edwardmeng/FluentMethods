using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Div<T>(this ILGenerator il, T value) => il.Ldc(value).Div();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Div(this ILGenerator il) => il.FluentEmit(OpCodes.Div);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, char value) => il.Div<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, byte value) => il.Div<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, sbyte value) => il.Div<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, short value) => il.Div<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, ushort value) => il.Div<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, int value) => il.Div<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, uint value) => il.Div<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, long value) => il.Div<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, ulong value) => il.Div<ulong>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, float value) => il.Div<float>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Div the evaluation stack value by</param>
    public static ILGenerator Div(this ILGenerator il, double value) => il.Div<double>(value);
}