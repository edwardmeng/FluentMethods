using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfGreaterThan<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        return il.IfGreater();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, char value) => il.IfGreaterThan<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, byte value) => il.IfGreaterThan<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, sbyte value) => il.IfGreaterThan<sbyte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, short value) => il.IfGreaterThan<short>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, ushort value) => il.IfGreaterThan<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, int value) => il.IfGreaterThan<int>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, uint value) => il.IfGreaterThan<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, long value) => il.IfGreaterThan<long>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, ulong value) => il.IfGreaterThan<ulong>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, float value) => il.IfGreaterThan<float>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThan(this BranchILGenerator il, double value) => il.IfGreaterThan<double>(value);
}