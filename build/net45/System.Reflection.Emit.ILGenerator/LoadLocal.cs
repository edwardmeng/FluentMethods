using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes the value of the given local onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to get the value of</param>
    public static ILGenerator LoadLocal(this ILGenerator il, LocalBuilder local)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        switch (local.LocalIndex)
        {
            case 0:
                il.Emit(OpCodes.Ldloc_0);
                break;
            case 1:
                il.Emit(OpCodes.Ldloc_1);
                break;
            case 2:
                il.Emit(OpCodes.Ldloc_2);
                break;
            default:
                il.Emit(local.LocalIndex <= 255 ? OpCodes.Ldloc_S : OpCodes.Ldloc, local);
                break;
        }
        return il;
    }
}