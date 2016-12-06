﻿using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator FromUnsignedTo(this ILGenerator il, Type type) => il.Conv_Ovf_Un(type);

    public static ILGenerator FromUnsignedTo<T>(this ILGenerator il) where T:struct => il.Conv_Ovf_Un<T>();

#if Net45 || NetCore
    public static ILGenerator FromUnsignedTo(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv_Ovf_Un(type);
#endif
}