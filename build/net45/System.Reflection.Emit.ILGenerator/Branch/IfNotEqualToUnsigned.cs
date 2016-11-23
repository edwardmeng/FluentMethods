using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator IfNotEqualToUnsigned<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        return il.IfNotEqualUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is not equal to the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfNotEqualToUnsigned(this BranchILGenerator il, char value) => il.IfNotEqualToUnsigned<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is not equal to the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfNotEqualToUnsigned(this BranchILGenerator il, byte value) => il.IfNotEqualToUnsigned<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is not equal to the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfNotEqualToUnsigned(this BranchILGenerator il, uint value) => il.IfNotEqualToUnsigned<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is not equal to the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfNotEqualToUnsigned(this BranchILGenerator il, ushort value) => il.IfNotEqualToUnsigned<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is not equal to the given
    ///     value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfNotEqualToUnsigned(this BranchILGenerator il, ulong value) => il.IfNotEqualToUnsigned<ulong>(value);
}