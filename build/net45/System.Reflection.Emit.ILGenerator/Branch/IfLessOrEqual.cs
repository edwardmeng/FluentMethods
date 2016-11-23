using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and branches to the given label if the first is less than or
    ///     equal to the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IfLessOrEqual(this BranchILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.IL.Emit(il.ShortForm ? OpCodes.Ble_S : OpCodes.Ble, il.Label);
        return il.IL;
    }
}