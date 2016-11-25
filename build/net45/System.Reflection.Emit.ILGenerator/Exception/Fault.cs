using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGeneratorScope Fault(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginFaultBlock();
        return new ILGeneratorScope(il);
    }
}