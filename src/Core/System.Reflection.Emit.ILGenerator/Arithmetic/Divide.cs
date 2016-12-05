using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Divide(this ILGenerator il) => il.Div();

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, char value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, byte value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, sbyte value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, short value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, ushort value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, int value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, uint value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, long value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, ulong value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, float value) => il.Div(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Divide(this ILGenerator il, double value) => il.Div(value);
}