using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Add<T>(this ILGenerator il, T value) => il.Ldc(value).Add();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and adds them together
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Add(this ILGenerator il) => il.FluentEmit(OpCodes.Add);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, char value) => il.Add<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, byte value) => il.Add<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, sbyte value) => il.Add<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, short value) => il.Add<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, ushort value) => il.Add<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, int value) => il.Add<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, uint value) => il.Add<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, long value) => il.Add<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, ulong value) => il.Add<ulong>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, float value) => il.Add<float>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, double value) => il.Add<double>(value);
}