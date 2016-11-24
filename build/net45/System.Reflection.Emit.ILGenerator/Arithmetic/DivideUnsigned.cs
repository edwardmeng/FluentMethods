﻿using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and divides the first by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Div_Un);
        return il;
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, char value)
    {
        return il.LoadConst(value).DivideUnsigned();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).DivideUnsigned();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).DivideUnsigned();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).DivideUnsigned();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).DivideUnsigned();
    }
}