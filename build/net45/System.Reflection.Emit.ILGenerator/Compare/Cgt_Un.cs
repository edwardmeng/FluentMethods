using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Cgt_Un<T>(this ILGenerator il, T value) => il.Ldc(value).Cgt_Un();

    /// <summary>
    ///     Pops two integer values from the evaluation stack and pushes the result of comparing whether the first is greater
    ///     than the second, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Cgt_Un(this ILGenerator il) => il.FluentEmit(OpCodes.Cgt_Un);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Cgt_Un(this ILGenerator il, char value) => il.Cgt_Un<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Cgt_Un(this ILGenerator il, byte value) => il.Cgt_Un<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Cgt_Un(this ILGenerator il, ushort value) => il.Cgt_Un<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Cgt_Un(this ILGenerator il, uint value) => il.Cgt_Un<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is greater than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Cgt_Un(this ILGenerator il, ulong value) => il.Cgt_Un<ulong>(value);
}