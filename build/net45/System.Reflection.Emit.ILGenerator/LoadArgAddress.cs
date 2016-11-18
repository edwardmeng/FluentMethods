using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Loads the address of the specified argument onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to load.</param>
    public static ILGenerator LoadArgAddress(this ILGenerator il, ushort index)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (index <= 255)
            il.Emit(OpCodes.Ldarga_S, (byte) index);
        else
            il.Emit(OpCodes.Ldarga, index);
        return il;
    }
}