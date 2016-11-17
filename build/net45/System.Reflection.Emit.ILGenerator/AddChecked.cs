using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and adds them together with a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator AddChecked(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Add_Ovf);
        return il;
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddChecked(this ILGenerator il, int value)
    {
        return il.LoadConst(value).AddChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddChecked(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).AddChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddChecked(this ILGenerator il, long value)
    {
        return il.LoadConst(value).AddChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddChecked(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).AddChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddChecked(this ILGenerator il, float value)
    {
        return il.LoadConst(value).AddChecked();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddChecked(this ILGenerator il, double value)
    {
        return il.LoadConst(value).AddChecked();
    }
}