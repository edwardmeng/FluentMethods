using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfLessThanOrEqualToUnsigned<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        return il.IfLessOrEqualUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualToUnsigned(this BranchILGenerator il, char value) => il.IfLessThanOrEqualToUnsigned<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualToUnsigned(this BranchILGenerator il, byte value) => il.IfLessThanOrEqualToUnsigned<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualToUnsigned(this BranchILGenerator il, uint value) => il.IfLessThanOrEqualToUnsigned<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualToUnsigned(this BranchILGenerator il, ushort value) => il.IfLessThanOrEqualToUnsigned<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is less than or equal to the
    ///     given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfLessThanOrEqualToUnsigned(this BranchILGenerator il, ulong value) => il.IfLessThanOrEqualToUnsigned<ulong>(value);
}