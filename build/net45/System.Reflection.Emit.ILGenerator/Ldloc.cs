using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Loads the local variable at a specific index onto the evaluation stack.
    /// </summary>
    public static ILGenerator Ldloc(this ILGenerator il, LocalBuilder local)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldloc, local);
        return il;
    }
}