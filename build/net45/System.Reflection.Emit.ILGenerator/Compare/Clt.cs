using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Clt<T>(this ILGenerator il, T value) => il.LoadConst(value).Clt();

    /// <summary>
    ///     Pops two integer values from the evaluation stack and pushes the result of comparing whether the first is less than
    ///     the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Clt(this ILGenerator il) => il.FluentEmit(OpCodes.Clt);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, char value) => il.Clt<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, byte value) => il.Clt<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, sbyte value) => il.Clt<sbyte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, short value) => il.Clt<short>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, ushort value) => il.Clt<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, int value) => il.Clt<int>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, uint value) => il.Clt<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, long value) => il.Clt<long>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, ulong value) => il.Clt<ulong>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, float value) => il.Clt<float>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt(this ILGenerator il, double value) => il.Clt<double>(value);
}