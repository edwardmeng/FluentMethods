using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGeneratorScope Finally(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginFinallyBlock();
        return new ILGeneratorScope(il);
    }
}