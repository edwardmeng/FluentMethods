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

#if NetCore || Net45
    
    public static LocalBuilder DeclareLocal(this ILGenerator il, System.Reflection.TypeInfo type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return il.DeclareLocal(type.AsType());
    }

    public static LocalBuilder DeclareLocal(this ILGenerator il, System.Reflection.TypeInfo type, bool pinned)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return il.DeclareLocal(type.AsType(), pinned);
    }

#endif
}