using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Short-cut to load the first argument - which is the this reference in instance methods
    /// </summary>
    public static ILGenerator LoadThis(this ILGenerator il)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        il.Emit(OpCodes.Ldarg_0);
        return il;
    }
}