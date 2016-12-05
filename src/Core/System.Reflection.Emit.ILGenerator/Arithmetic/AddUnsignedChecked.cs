using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two values from the top of the evaluation stack and adds them together without regard for sign, and a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator AddUnsignedChecked(this ILGenerator il) => il.Add_Ovf_Un();

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddUnsignedChecked(this ILGenerator il, char value) => il.Add_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddUnsignedChecked(this ILGenerator il, byte value) => il.Add_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddUnsignedChecked(this ILGenerator il, uint value) => il.Add_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddUnsignedChecked(this ILGenerator il, ulong value) => il.Add_Ovf_Un(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator AddUnsignedChecked(this ILGenerator il, ushort value) => il.Add_Ovf_Un(value);
}