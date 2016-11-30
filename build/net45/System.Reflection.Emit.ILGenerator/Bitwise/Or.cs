using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Or<T>(this ILGenerator il, T value) => il.Ldc(value).Or();

    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise or operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Or(this ILGenerator il) => il.FluentEmit(OpCodes.Or);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, bool value) => il.Or<bool>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, byte value) => il.Or<byte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, sbyte value) => il.Or<sbyte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, short value) => il.Or<short>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, ushort value) => il.Or<ushort>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, int value) => il.Or<int>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, uint value) => il.Or<uint>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, long value) => il.Or<long>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise or operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise or the evaluation stack value with</param>
    public static ILGenerator Or(this ILGenerator il, ulong value) => il.Or<ulong>(value);
}