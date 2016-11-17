using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Returns from the current method, pushing a return value (if present) from the callee's
    /// evaluation stack onto the caller's evaluation stack.
    /// </summary>
    public static ILGenerator Return(this ILGenerator il)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ret);
        return il;
    }
}