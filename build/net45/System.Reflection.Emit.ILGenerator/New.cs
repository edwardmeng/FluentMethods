using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pushes a null reference (type O) onto the evaluation stack.
    /// </summary>
    public static ILGenerator New(this ILGenerator il)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldnull);
        return il;
    }
}