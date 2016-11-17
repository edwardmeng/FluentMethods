using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise shiftrightunsigned operation on them
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Shr_Un);
        return il;
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, int value)
    {
        return il.LoadConst(value).ShiftRightUnsigned();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).ShiftRightUnsigned();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, long value)
    {
        return il.LoadConst(value).ShiftRightUnsigned();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftrightunsigned operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftrightunsigned the evaluation stack value by</param>
    public static ILGenerator ShiftRightUnsigned(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).ShiftRightUnsigned();
    }
}