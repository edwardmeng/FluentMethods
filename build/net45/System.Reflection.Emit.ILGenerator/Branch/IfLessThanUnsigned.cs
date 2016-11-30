using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfLessThanUnsigned<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.Ldc(value);
        return il.IfLessUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value,
    ///     without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanUnsigned(this BranchILGenerator il, char value) => il.IfLessThanUnsigned<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value,
    ///     without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanUnsigned(this BranchILGenerator il, byte value) => il.IfLessThanUnsigned<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value,
    ///     without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanUnsigned(this BranchILGenerator il, uint value) => il.IfLessThanUnsigned<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value,
    ///     without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanUnsigned(this BranchILGenerator il, ushort value) => il.IfLessThanUnsigned<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than the given value,
    ///     without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanUnsigned(this BranchILGenerator il, ulong value) => il.IfLessThanUnsigned<ulong>(value);
}