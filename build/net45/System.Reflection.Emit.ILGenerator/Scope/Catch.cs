using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginCatchBlock(exceptionType);
        return new ILGeneratorScope(il);
    }

    public static ILGeneratorScope Catch<T>(this ILGenerator il) where T : Exception
    {
        return il.Catch(typeof(T));
    }

    public static ILGeneratorScope Catch(this ILGenerator il)
    {
        return il.Catch(null);
    }
}