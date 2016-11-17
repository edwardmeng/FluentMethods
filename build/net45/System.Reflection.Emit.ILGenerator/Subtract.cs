using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Subtract(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Sub);
        return il;
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Subtract(this ILGenerator il, int value)
    {
        return il.LoadConst(value).Subtract();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Subtract(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).Subtract();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Subtract(this ILGenerator il, long value)
    {
        return il.LoadConst(value).Subtract();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Subtract(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).Subtract();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Subtract(this ILGenerator il, float value)
    {
        return il.LoadConst(value).Subtract();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value subtracts the second from the first
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to subtract from the evaluation stack value</param>
    public static ILGenerator Subtract(this ILGenerator il, double value)
    {
        return il.LoadConst(value).Subtract();
    }
}