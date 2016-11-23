using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfGreaterThanUnsigned<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        return il.IfGreaterUnsigned(il.Label);
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanUnsigned(this BranchILGenerator il, char value) => il.IfGreaterThanUnsigned<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanUnsigned(this BranchILGenerator il, byte value) => il.IfGreaterThanUnsigned<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanUnsigned(this BranchILGenerator il, ushort value) => il.IfGreaterThanUnsigned<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanUnsigned(this BranchILGenerator il, uint value) => il.IfGreaterThanUnsigned<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanUnsigned(this BranchILGenerator il, ulong value) => il.IfGreaterThanUnsigned<ulong>(value);
}