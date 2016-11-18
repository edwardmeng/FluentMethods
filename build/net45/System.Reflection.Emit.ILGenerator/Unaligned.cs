using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Indicates that the next operation should not assume that its arguments are properly aligned
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Unaligned(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Unaligned);
        return il;
    }
}