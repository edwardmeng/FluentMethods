using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Loads the address of the local variable at a specific index onto the evaluation stack.
    /// </summary>
    public static ILGenerator Ldloca(this ILGenerator il, LocalBuilder local)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldloca, local);
        return il;
    }
}