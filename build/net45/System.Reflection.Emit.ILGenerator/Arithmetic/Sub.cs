using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Sub<T>(this ILGenerator il, T value) => il.LoadConst(value).Sub();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Sub(this ILGenerator il) => il.FluentEmit(OpCodes.Sub);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, char value) => il.Sub<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, byte value) => il.Sub<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, sbyte value) => il.Sub<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, short value) => il.Sub<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, ushort value) => il.Sub<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, int value) => il.Sub<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, uint value) => il.Sub<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, long value) => il.Sub<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, ulong value) => il.Sub<ulong>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, float value) => il.Sub<float>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to Sub from the evaluation stack value</param>
    public static ILGenerator Sub(this ILGenerator il, double value) => il.Sub<double>(value);
}