using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfGreaterThanOrEqualTo<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.Ldc(value);
        return il.IfGreaterOrEqual();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, char value) => il.IfGreaterThanOrEqualTo<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, byte value) => il.IfGreaterThanOrEqualTo<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, sbyte value) => il.IfGreaterThanOrEqualTo<sbyte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, short value) => il.IfGreaterThanOrEqualTo<short>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, ushort value) => il.IfGreaterThanOrEqualTo<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, int value) => il.IfGreaterThanOrEqualTo<int>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, uint value) => il.IfGreaterThanOrEqualTo<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, long value) => il.IfGreaterThanOrEqualTo<long>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, ulong value) => il.IfGreaterThanOrEqualTo<ulong>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, float value) => il.IfGreaterThanOrEqualTo<float>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualTo(this BranchILGenerator il, double value) => il.IfGreaterThanOrEqualTo<double>(value);
}