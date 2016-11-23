using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator IfGreaterThanOrEqualToUnsigned<T>(this BranchILGenerator il, T value)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadConst(value);
        return il.IfGreaterOrEqualUnsigned();
    }

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualToUnsigned(this BranchILGenerator il, char value) => il.IfGreaterThanOrEqualToUnsigned<char>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualToUnsigned(this BranchILGenerator il, byte value) => il.IfGreaterThanOrEqualToUnsigned<byte>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualToUnsigned(this BranchILGenerator il, ushort value) => il.IfGreaterThanOrEqualToUnsigned<ushort>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualToUnsigned(this BranchILGenerator il, uint value) => il.IfGreaterThanOrEqualToUnsigned<uint>(value);

    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the given label if it is greater than or equal to
    ///     the given value, without regard for sign
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to compare to the evaluation stack value</param>
    public static ILGenerator IfGreaterThanOrEqualToUnsigned(this BranchILGenerator il, ulong value) => il.IfGreaterThanOrEqualToUnsigned<ulong>(value);
}