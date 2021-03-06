﻿using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, char value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, byte value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, sbyte value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, short value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, ushort value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, int value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, uint value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, long value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, ulong value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, float value) => il.Cgt(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator CompareGreaterThan(this ILGenerator il, double value) => il.Cgt(value);
}