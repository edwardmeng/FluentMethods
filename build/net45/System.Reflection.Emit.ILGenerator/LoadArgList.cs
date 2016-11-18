using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes an unmanaged pointer to the argument list of the current method
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator LoadArgList(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Arglist);
        return il;
    }
}