﻿using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops the top value off the evaluation stack and discards it
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Pop(this ILGenerator il) => il.FluentEmit(OpCodes.Pop);
}