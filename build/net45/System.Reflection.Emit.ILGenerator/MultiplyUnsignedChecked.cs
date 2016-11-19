using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and multiples them together without regard for sign, and a
    ///     check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Mul_Ovf_Un);
        return il;
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, char value)
    {
        return il.LoadConst(value).MultiplyUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).MultiplyUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).MultiplyUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).MultiplyUnsignedChecked();
    }

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value multiples them together without regard
    ///     for sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyUnsignedChecked(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).MultiplyUnsignedChecked();
    }
}