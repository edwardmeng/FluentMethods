using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int16.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, short value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int16.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, ushort value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int32.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, int value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type UInt32 onto the evaluation stack as an int32.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, uint value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type Int64 onto the evaluation stack as an int64.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, long value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type UInt64 onto the evaluation stack as an int64.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, ulong value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type float onto the evaluation stack as type F (float).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, float value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type double onto the evaluation stack as type F (float).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, double value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type boolean onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, bool value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type char onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, char value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type byte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, byte value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type sbyte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, sbyte value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type string onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, string value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type decimal onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, decimal value) => il.Ldc(value);

    /// <summary>
    ///     Pushes a supplied value of type <see cref="DateTime"/> onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, DateTime value) => il.Ldc(value);
}