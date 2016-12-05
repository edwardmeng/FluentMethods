using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Xor<T>(this ILGenerator il, T value) => il.Ldc(value).Xor();

    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise xor operation on them
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Xor(this ILGenerator il) => il.FluentEmit(OpCodes.Xor);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, bool value) => il.Xor<bool>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, byte value) => il.Xor<byte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, sbyte value) => il.Xor<sbyte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, short value) => il.Xor<short>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, ushort value) => il.Xor<ushort>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, int value) => il.Xor<int>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, uint value) => il.Xor<uint>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, long value) => il.Xor<long>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, ulong value) => il.Xor<ulong>(value);
}