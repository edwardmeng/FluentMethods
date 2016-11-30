using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfLessThan<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.Ldc(value);
        return il.IfLess();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, char value) => il.IfLessThan<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, byte value) => il.IfLessThan<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, sbyte value) => il.IfLessThan<sbyte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, ushort value) => il.IfLessThan<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, short value) => il.IfLessThan<short>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, int value) => il.IfLessThan<int>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, uint value) => il.IfLessThan<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, long value) => il.IfLessThan<long>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, ulong value) => il.IfLessThan<ulong>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, float value) => il.IfLessThan<float>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThan(this BranchILGenerator il, double value) => il.IfLessThan<double>(value);
}