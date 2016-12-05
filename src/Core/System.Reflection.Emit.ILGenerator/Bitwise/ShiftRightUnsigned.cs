using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise shiftrightunsigned operation on them
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il) => il.Shr_Un();

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, char value) => il.Shr_Un(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, byte value) => il.Shr_Un(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, ushort value) => il.Shr_Un(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, uint value) => il.Shr_Un(value);
}