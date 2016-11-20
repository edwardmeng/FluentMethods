using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise shiftright operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator ShiftRight(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Shr);
        return il;
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, char value)
    {
        return il.LoadConst(value).ShiftRight();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).ShiftRight();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, sbyte value)
    {
        return il.LoadConst(value).ShiftRight();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, short value)
    {
        return il.LoadConst(value).ShiftRight();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).ShiftRight();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, int value)
    {
        return il.LoadConst(value).ShiftRight();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise shiftright operation by the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise shiftright the evaluation stack value by</param>
    public static ILGenerator ShiftRight(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).ShiftRight();
    }
}