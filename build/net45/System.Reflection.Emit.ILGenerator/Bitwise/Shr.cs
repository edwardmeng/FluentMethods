using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Shr<T>(this ILGenerator il, T value) => il.Ldc(value).Shr();

    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise Shr operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Shr(this ILGenerator il) => il.FluentEmit(OpCodes.Shr);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, char value) => il.Shr<char>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, byte value) => il.Shr<byte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, sbyte value) => il.Shr<sbyte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, short value) => il.Shr<short>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, ushort value) => il.Shr<ushort>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, int value) => il.Shr<int>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr the evaluation stack value by</param>
    public static ILGenerator Shr(this ILGenerator il, uint value) => il.Shr<uint>(value);
}