using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Sub_Ovf_Un<T>(this ILGenerator il, T value) => il.LoadConst(value).Sub_Ovf_Un();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and subtracts the second from the first without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Sub_Ovf_Un(this ILGenerator il) => il.FluentEmit(OpCodes.Sub_Ovf_Un);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Sub_Ovf_Un(this ILGenerator il, char value) => il.Sub_Ovf_Un<char>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Sub_Ovf_Un(this ILGenerator il, byte value) => il.Sub_Ovf_Un<byte>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Sub_Ovf_Un(this ILGenerator il, ushort value) => il.Sub_Ovf_Un<ushort>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Sub_Ovf_Un(this ILGenerator il, uint value) => il.Sub_Ovf_Un<uint>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Sub_Ovf_Un(this ILGenerator il, ulong value) => il.Sub_Ovf_Un<ulong>(value);
}