using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and finds the remainder when the first is divided by the
    ///     second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator RemainderUnsigned(this ILGenerator il) => il.Rem_Un();

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator RemainderUnsigned(this ILGenerator il, char value) => il.Rem_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator RemainderUnsigned(this ILGenerator il, byte value) => il.Rem_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator RemainderUnsigned(this ILGenerator il, ushort value) => il.Rem_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator RemainderUnsigned(this ILGenerator il, uint value) => il.Rem_Un(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value finds the remainder when the first is
    ///     divided by the second without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to divide the evaluation stack value by</param>
    public static ILGenerator RemainderUnsigned(this ILGenerator il, ulong value) => il.Rem_Un(value);
}