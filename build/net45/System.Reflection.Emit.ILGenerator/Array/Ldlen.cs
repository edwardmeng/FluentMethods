using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an array reference off the evaluation stack and pushes the length of the array
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Ldlen(this ILGenerator il) => il.FluentEmit(OpCodes.Ldlen);
}