using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator And<T>(this ILGenerator il, T value) => il.Ldc(value).And();

    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise and operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator And(this ILGenerator il) => il.FluentEmit(OpCodes.And);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, bool value) => il.And<bool>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, byte value) => il.And<byte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, sbyte value) => il.And<sbyte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, short value) => il.And<short>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, ushort value) => il.And<ushort>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, int value) => il.And<int>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, uint value) => il.And<uint>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, long value) => il.And<long>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, ulong value) => il.And<ulong>(value);
}