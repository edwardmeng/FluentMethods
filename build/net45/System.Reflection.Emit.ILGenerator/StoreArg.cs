using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pop the value on the top of the evaluation stack and stores it in the specified argument
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to store the value in.</param>
    public static ILGenerator StoreArg(this ILGenerator il, ushort index)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (index <= 255)
        {
            il.Emit(OpCodes.Starg_S, (byte)index);
        }
        else
        {
            il.Emit(OpCodes.Starg, index);
        }
        return il;
    }
}