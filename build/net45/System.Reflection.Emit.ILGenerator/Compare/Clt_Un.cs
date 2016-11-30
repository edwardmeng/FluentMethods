using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Clt_Un<T>(this ILGenerator il, T value) => il.LoadConst(value).Clt_Un();

    /// <summary>
    ///     Pops two integer values from the evaluation stack and pushes the result of comparing whether the first is less than
    ///     the second, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Clt_Un(this ILGenerator il) => il.FluentEmit(OpCodes.Clt_Un);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt_Un(this ILGenerator il, char value) => il.Clt_Un<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt_Un(this ILGenerator il, byte value) => il.Clt_Un<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt_Un(this ILGenerator il, ushort value) => il.Clt_Un<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt_Un(this ILGenerator il, uint value) => il.Clt_Un<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and pushes the result of comparing whether it is less than the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator Clt_Un(this ILGenerator il, ulong value) => il.Clt_Un<ulong>(value);
}