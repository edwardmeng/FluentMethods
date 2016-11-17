using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Signals an attached debugger to break execution
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Break(this ILGenerator il)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Break);
        return il;
    }
}