using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and multiples them together with a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Mul_Ovf);
        return il;
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il, int value)
    {
        return il.LoadConst(value).MultiplyChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).MultiplyChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il, long value)
    {
        return il.LoadConst(value).MultiplyChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).MultiplyChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il, float value)
    {
        return il.LoadConst(value).MultiplyChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together with a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator MultiplyChecked(this ILGenerator il, double value)
    {
        return il.LoadConst(value).MultiplyChecked();
    }
}