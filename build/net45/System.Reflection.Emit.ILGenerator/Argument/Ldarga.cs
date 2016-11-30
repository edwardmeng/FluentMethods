using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Loads the address of the specified argument onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to load.</param>
    public static ILGenerator Ldarga(this ILGenerator il, ushort index) 
        => index <= 255 ? il.FluentEmit(OpCodes.Ldarga_S, (byte)index) : il.FluentEmit(OpCodes.Ldarga, index);
}