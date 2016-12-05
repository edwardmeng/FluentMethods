using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and multiples them together
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Multiply(this ILGenerator il) => il.Mul();

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, char value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, byte value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, sbyte value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, short value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, ushort value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, int value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, uint value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, long value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, ulong value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, float value) => il.Mul(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value multiples them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to multiply with the evaluation stack value</param>
    public static ILGenerator Multiply(this ILGenerator il, double value) => il.Mul(value);
}