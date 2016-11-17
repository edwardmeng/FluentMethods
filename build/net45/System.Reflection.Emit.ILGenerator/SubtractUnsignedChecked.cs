using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and subtracts the second from the first without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Sub_Ovf_Un);
        return il;
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il, int value)
    {
        return il.LoadConst(value).SubtractUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).SubtractUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il, long value)
    {
        return il.LoadConst(value).SubtractUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).SubtractUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il, float value)
    {
        return il.LoadConst(value).SubtractUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    ///     without regard for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator SubtractUnsignedChecked(this ILGenerator il, double value)
    {
        return il.LoadConst(value).SubtractUnsignedChecked();
    }
}