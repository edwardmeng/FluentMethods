using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop the value on the top of the evaluation stack and stores it in the specified argument
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in.</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index) 
        => index <= 255 ? il.FluentEmit(OpCodes.Starg_S, (byte)index) : il.FluentEmit(OpCodes.Starg, index);

    private static ILGenerator Starg<T>(this ILGenerator il, ushort index, T value) => il.Ldc(value).Starg(index);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, char value) => il.Starg<char>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, bool value) => il.Starg<bool>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, byte value) => il.Starg<byte>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, sbyte value) => il.Starg<sbyte>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, short value) => il.Starg<short>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, ushort value) => il.Starg<ushort>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, int value) => il.Starg<int>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, uint value) => il.Starg<uint>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, long value) => il.Starg<long>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, ulong value) => il.Starg<ulong>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, float value) => il.Starg<float>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, double value) => il.Starg<double>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, string value) => il.Starg<string>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator Starg(this ILGenerator il, ushort index, decimal value) => il.Starg<decimal>(index, value);
}