using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Performs no operation
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator NoOperation(this ILGenerator il)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Nop);
        return il;
    }
}