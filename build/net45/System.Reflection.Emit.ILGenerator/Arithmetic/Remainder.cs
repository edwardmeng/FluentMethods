using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and finds the remainder when the first is divided by the
    ///     second
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Remainder(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Rem);
        return il;
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, char value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, sbyte value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, short value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, int value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, long value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, float value)
    {
        return il.LoadConst(value).Remainder();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Remainder(this ILGenerator il, double value)
    {
        return il.LoadConst(value).Remainder();
    }
}