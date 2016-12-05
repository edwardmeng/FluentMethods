using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops a reference from the evaluation stack and branches to the given label if it is the null reference
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IfNull(this BranchILGenerator il)
    {
        if (il == null) throw new ArgumentNullException(nameof(il));
        il.IL.LoadNull();
        return il.IfEqual();
    }
}