using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfLessThanOrEqualTo<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        return il.IfLessOrEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, char value) => il.IfLessThanOrEqualTo<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, byte value) => il.IfLessThanOrEqualTo<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, sbyte value) => il.IfLessThanOrEqualTo<sbyte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, short value) => il.IfLessThanOrEqualTo<short>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, ushort value) => il.IfLessThanOrEqualTo<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, int value) => il.IfLessThanOrEqualTo<int>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, uint value) => il.IfLessThanOrEqualTo<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, long value) => il.IfLessThanOrEqualTo<long>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, ulong value) => il.IfLessThanOrEqualTo<ulong>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, float value) => il.IfLessThanOrEqualTo<float>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualTo(this BranchILGenerator il, double value) => il.IfLessThanOrEqualTo<double>(value);
}