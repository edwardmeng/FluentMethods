using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGeneratorScope Scope(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginScope();
        return new ILGeneratorScope(il, il.EndScope);
    }
}