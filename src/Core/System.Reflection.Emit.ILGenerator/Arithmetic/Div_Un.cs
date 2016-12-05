using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Div_Un<T>(this ILGenerator il, T value) => il.Ldc(value).Div_Un();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and divides the first by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Div_Un(this ILGenerator il) => il.FluentEmit(OpCodes.Div_Un);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Div_Un(this ILGenerator il, char value) => il.Div_Un<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Div_Un(this ILGenerator il, byte value) => il.Div_Un<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Div_Un(this ILGenerator il, ushort value) => il.Div_Un<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Div_Un(this ILGenerator il, uint value) => il.Div_Un<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value divides the first by the second without
    ///     regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator Div_Un(this ILGenerator il, ulong value) => il.Div_Un<ulong>(value);
}