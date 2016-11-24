﻿using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareLessThanUnsigned(this ILGenerator il, char value)
    {
        return il.LoadConst(value).CompareLessUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareLessThanUnsigned(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).CompareLessUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareLessThanUnsigned(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).CompareLessUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareLessThanUnsigned(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).CompareLessUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareLessThanUnsigned(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).CompareLessUnsigned();
    }
}