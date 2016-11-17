using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise and operation on them
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator And(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.And);
        return il;
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, int value)
    {
        return il.LoadConst(value).And();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).And();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, long value)
    {
        return il.LoadConst(value).And();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise and operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise and the evaluation stack value with</param>
    public static ILGenerator And(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).And();
    }
}