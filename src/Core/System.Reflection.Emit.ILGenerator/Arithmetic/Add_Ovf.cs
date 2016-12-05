using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Add_Ovf<T>(this ILGenerator il, T value) => il.Ldc(value).Add_Ovf();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and adds them together with a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Add_Ovf(this ILGenerator il) => il.FluentEmit(OpCodes.Add_Ovf);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, char value) => il.Add_Ovf<char>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, byte value) => il.Add_Ovf<byte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, sbyte value) => il.Add_Ovf<sbyte>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, ushort value) => il.Add_Ovf<ushort>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, short value) => il.Add_Ovf<short>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, int value) => il.Add_Ovf<int>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, uint value) => il.Add_Ovf<uint>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, long value) => il.Add_Ovf<long>(value);

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together with a check for
    ///     overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf(this ILGenerator il, ulong value) => il.Add_Ovf<ulong>(value);
}