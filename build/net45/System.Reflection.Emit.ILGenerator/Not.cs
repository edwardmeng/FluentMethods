using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pop an integer value from the evaluation stack and perform a bitwise not operation on it
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Not(this ILGenerator il)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Not);
        return il;
    }
}