using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator ConvertToChecked(this ILGenerator il, Type type) => il.Conv_Ovf(type);

    public static ILGenerator ConvertToChecked<T>(this ILGenerator il) => il.Conv_Ovf<T>();

#if Net45 || NetCore
    public static ILGenerator ConvertToChecked(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv_Ovf(type);
#endif
}