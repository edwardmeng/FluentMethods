using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise shiftright operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator ShiftRight(this ILGenerator il) => il.Shr();

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, char value) => il.Shr(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, byte value) => il.Shr(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, sbyte value) => il.Shr(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, short value) => il.Shr(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, ushort value) => il.Shr(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, int value) => il.Shr(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, uint value) => il.Shr(value);
}