using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Rem<T>(this ILGenerator il, T value) => il.Ldc(value).Rem();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and finds the Rem when the first is divided by the
    ///     second
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Rem(this ILGenerator il) => il.FluentEmit(OpCodes.Rem);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, char value) => il.Rem<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, byte value) => il.Rem<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, sbyte value) => il.Rem<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, short value) => il.Rem<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, ushort value) => il.Rem<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, int value) => il.Rem<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, uint value) => il.Rem<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, long value) => il.Rem<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, ulong value) => il.Rem<ulong>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, float value) => il.Rem<float>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the Rem when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Rem(this ILGenerator il, double value) => il.Rem<double>(value);
}