using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator ConvertTo(this ILGenerator il, Type type) => il.Conv(type);

    public static ILGenerator ConvertTo<T>(this ILGenerator il) => il.Conv<T>();

#if Net45 || NetCore
    public static ILGenerator ConvertTo(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv(type);
#endif
}