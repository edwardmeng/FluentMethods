using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Loads an argument (referenced by a specified index value) onto the stack.
    /// </summary>
    public static ILGenerator Ldarg(this ILGenerator il, int index)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        switch (index)
        {
            case 0:
                il.Emit(OpCodes.Ldarg_0);
                return il;
            case 1:
                il.Emit(OpCodes.Ldarg_1);
                return il;
            case 2:
                il.Emit(OpCodes.Ldarg_2);
                return il;
            case 3:
                il.Emit(OpCodes.Ldarg_3);
                return il;
            default:
                il.Emit(OpCodes.Ldarg, index);
                return il;
        }
        return il;
    }
}