using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGeneratorScope Try(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginExceptionBlock();
        return new ILGeneratorScope(il, il.EndExceptionBlock);
    }
}