using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop the value on the top of the evaluation stack and stores it in the specified argument
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in.</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (index <= 255)
            il.Emit(OpCodes.Starg_S, (byte) index);
        else
            il.Emit(OpCodes.Starg, index);
        return il;
    }

    private static ILGenerator StoreArg<T>(this ILGenerator il, ushort index, T value)
    {
        return il.LoadConst(value).StoreArg(index);
    }

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, char value) => il.StoreArg<char>(index,value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, bool value) => il.StoreArg<bool>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, byte value) => il.StoreArg<byte>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, sbyte value) => il.StoreArg<sbyte>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, short value) => il.StoreArg<short>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, ushort value) => il.StoreArg<ushort>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, int value) => il.StoreArg<int>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, uint value) => il.StoreArg<uint>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, long value) => il.StoreArg<long>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, ulong value) => il.StoreArg<ulong>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, float value) => il.StoreArg<float>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, double value) => il.StoreArg<double>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, string value) => il.StoreArg<string>(index, value);

    /// <summary>
    ///     Overwrite the specified argument with the given value.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in</param>
    /// <param name="value">The value to store in the argument</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index, decimal value) => il.StoreArg<decimal>(index, value);
}