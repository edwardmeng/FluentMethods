using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Shl<T>(this ILGenerator il, T value) => il.Ldc(value).Shl();

    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise Shl operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Shl(this ILGenerator il) => il.FluentEmit(OpCodes.Shl);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, char value) => il.Shl<char>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, byte value) => il.Shl<byte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, sbyte value) => il.Shl<sbyte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, short value) => il.Shl<short>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, ushort value) => il.Shl<ushort>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, int value) => il.Shl<int>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shl operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shl the evaluation stack value by</param>
    public static ILGenerator Shl(this ILGenerator il, uint value) => il.Shl<uint>(value);
}