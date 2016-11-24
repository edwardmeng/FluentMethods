using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise xor operation on them
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Xor(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Xor);
        return il;
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, bool value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, sbyte value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, short value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, int value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, long value)
    {
        return il.LoadConst(value).Xor();
    }

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise xor operation with the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise xor the evaluation stack value with</param>
    public static ILGenerator Xor(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).Xor();
    }
}