using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Shr_Un<T>(this ILGenerator il, T value) => il.Ldc(value).Shr_Un();

    /// <summary>
    ///     Pop two integer values from the evaluation stack and perform a bitwise Shr_Un operation on them
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Shr_Un(this ILGenerator il) => il.FluentEmit(OpCodes.Shr_Un);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr_Un operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr_Un the evaluation stack value by</param>
    public static ILGenerator Shr_Un(this ILGenerator il, char value) => il.Shr_Un<char>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr_Un operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr_Un the evaluation stack value by</param>
    public static ILGenerator Shr_Un(this ILGenerator il, byte value) => il.Shr_Un<byte>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr_Un operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr_Un the evaluation stack value by</param>
    public static ILGenerator Shr_Un(this ILGenerator il, ushort value) => il.Shr_Un<ushort>(value);

    /// <summary>
    ///     Pop an integer value from the evaluation stack and perform a bitwise Shr_Un operation by the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to bitwise Shr_Un the evaluation stack value by</param>
    public static ILGenerator Shr_Un(this ILGenerator il, uint value) => il.Shr_Un<uint>(value);
}