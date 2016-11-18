using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops the top value off the evaluation stack and discards it
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Pop(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Pop);
        return il;
    }

    /// <summary>
    ///     Pops <paramref name="n" /> values off the evaluation stack and discards them
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="n">The number of evaluation stack values to discard</param>
    public static ILGenerator Pop(this ILGenerator il, uint n)
    {
        for (var i = 0; i < n; i++)
            il.Emit(OpCodes.Pop);

        return il;
    }
}