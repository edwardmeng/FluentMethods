using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static LocalBuilder DeclareLocal<T>(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.DeclareLocal(typeof(T));
    }

    public static LocalBuilder DeclareLocal<T>(this ILGenerator il, bool pinned)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.DeclareLocal(typeof(T), pinned);
    }
}