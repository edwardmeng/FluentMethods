﻿using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops two integer values from the evaluation stack and pushes the result of comparing whether the first is greater
    ///     than the second
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator CompareGreater(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Cgt);
        return il;
    }
}