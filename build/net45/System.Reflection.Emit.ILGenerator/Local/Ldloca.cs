using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes the address of the given local onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to get the address of</param>
    public static ILGenerator Ldloca(this ILGenerator il, LocalBuilder local)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        return il.FluentEmit(local.LocalIndex <= 255 ? OpCodes.Ldloca_S : OpCodes.Ldloca, local);
    }
}