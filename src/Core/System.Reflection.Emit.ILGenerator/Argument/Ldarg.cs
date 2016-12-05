using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Loads an argument (referenced by a specified index value) onto the stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to load.</param>
    public static ILGenerator Ldarg(this ILGenerator il, ushort index)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        switch (index)
        {
            case 0:
                return il.FluentEmit(OpCodes.Ldarg_0);
            case 1:
                return il.FluentEmit(OpCodes.Ldarg_1);
            case 2:
                return il.FluentEmit(OpCodes.Ldarg_2);
            case 3:
                return il.FluentEmit(OpCodes.Ldarg_3);
            default:
                return index <= 255 ? il.FluentEmit(OpCodes.Ldarg_S, (byte)index) : il.FluentEmit(OpCodes.Ldarg, index);
        }
    }
}