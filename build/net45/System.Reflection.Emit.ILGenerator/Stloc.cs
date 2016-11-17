using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops the current value from the top of the evaluation stack and stores it in a the local variable list at a specified index.
    /// </summary>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Stloc, local);
        return il;
    }
}