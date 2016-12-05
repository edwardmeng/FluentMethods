using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and divides the first by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il) => il.Div_Un();

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, char value) => il.Div_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, byte value) => il.Div_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, ushort value) => il.Div_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, uint value) => il.Div_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator DivideUnsigned(this ILGenerator il, ulong value) => il.Div_Un(value);
}