using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Add_Ovf_Un<T>(this ILGenerator il, T value) => il.Ldc(value).Add_Ovf_Un();

    /// <summary>
    ///     Pops two values from the top of the evaluation stack and adds them together without regard for sign, and a check
    ///     for overflow
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Add_Ovf_Un(this ILGenerator il) => il.FluentEmit(OpCodes.Add_Ovf_Un);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf_Un(this ILGenerator il, char value) => il.Add_Ovf_Un<char>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf_Un(this ILGenerator il, byte value) => il.Add_Ovf_Un<byte>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf_Un(this ILGenerator il, uint value) => il.Add_Ovf_Un<uint>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf_Un(this ILGenerator il, ulong value) => il.Add_Ovf_Un<ulong>(value);

    /// <summary>
    ///     Pop a value from the top of the evaluation stack, and with the given value adds them together without regard for
    ///     sign, and a check for overflow
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to add the evaluation stack value to</param>
    public static ILGenerator Add_Ovf_Un(this ILGenerator il, ushort value) => il.Add_Ovf_Un<ushort>(value);
}