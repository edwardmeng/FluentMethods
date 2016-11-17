using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Loads an argument (referenced by a specified index value) onto the stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to load.</param>
    public static ILGenerator LoadArg(this ILGenerator il, ushort index)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        switch (index)
        {
            case 0:
                il.Emit(OpCodes.Ldarg_0);
                break;
            case 1:
                il.Emit(OpCodes.Ldarg_1);
                break;
            case 2:
                il.Emit(OpCodes.Ldarg_2);
                break;
            case 3:
                il.Emit(OpCodes.Ldarg_3);
                break;
            default:
                if (index<=255)
                {
                    il.Emit(OpCodes.Ldarg_S, (byte)index);
                }
                else
                {
                    il.Emit(OpCodes.Ldarg, index);
                }
                break;
        }
        return il;
    }
}