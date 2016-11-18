using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Duplicates the value on the top of the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Duplicate(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Dup);
        return il;
    }

    /// <summary>
    ///     Duplicates the value on the top of the evaluation stack <paramref name="n" /> times
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="n">The number of times to duplicate the value</param>
    public static ILGenerator Duplicate(this ILGenerator il, uint n)
    {
        for (var i = 0; i < n; i++)
            il.Emit(OpCodes.Dup);

        return il;
    }
}