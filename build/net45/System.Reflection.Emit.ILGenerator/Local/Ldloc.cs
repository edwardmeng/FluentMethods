using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes the value of the given local onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to get the value of</param>
    public static ILGenerator Ldloc(this ILGenerator il, LocalBuilder local)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        switch (local.LocalIndex)
        {
            case 0:
                return il.FluentEmit(OpCodes.Ldloc_0);
            case 1:
                return il.FluentEmit(OpCodes.Ldloc_1);
            case 2:
                return il.FluentEmit(OpCodes.Ldloc_2);
            default:
                return il.FluentEmit(local.LocalIndex <= 255 ? OpCodes.Ldloc_S : OpCodes.Ldloc, local);
        }
    }
}