using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and adds them together
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Add(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Add);
        return il;
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, char value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, byte value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, sbyte value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, short value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, ushort value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, int value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, uint value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, long value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, ulong value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, float value)
    {
        return il.LoadConst(value).Add();
    }

    /// <summary>
    ///     Pops a value from the top of the evaluation stack, and with the given value adds them together
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add(this ILGenerator il, double value)
    {
        return il.LoadConst(value).Add();
    }
}