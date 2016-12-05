using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise shiftleft operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator ShiftLeft(this ILGenerator il) => il.Shl();

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, char value) => il.Shl(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, byte value) => il.Shl(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, sbyte value) => il.Shl(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, short value) => il.Shl(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, ushort value) => il.Shl(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, int value) => il.Shl(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftleft operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftleft the evaluation stack value by</param>
    public static ILGenerator ShiftLeft(this ILGenerator il, uint value) => il.Shl(value);
}