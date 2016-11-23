using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfEqualTo<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        il.IfEqual();
        return il.IL;
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, char value) => il.IfEqualTo<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, bool value) => il.IfEqualTo<bool>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, sbyte value) => il.IfEqualTo<sbyte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, byte value) => il.IfEqualTo<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, short value) => il.IfEqualTo<short>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, ushort value) => il.IfEqualTo<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, int value) => il.IfEqualTo<int>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, uint value) => il.IfEqualTo<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, long value) => il.IfEqualTo<long>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, ulong value) => il.IfEqualTo<ulong>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, float value) => il.IfEqualTo<float>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is equal to the given value
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfEqualTo(this BranchILGenerator il, double value) => il.IfEqualTo<double>(value);
}