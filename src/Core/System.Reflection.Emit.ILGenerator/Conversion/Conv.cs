using System;
using System.Reflection;
using System.Reflection.Emit;
using FluentMethods;

public static partial class Extensions
{
    public static ILGenerator Conv(this ILGenerator il, Type type)
    {
        // Converts the signed value on the top of the evaluation stack to a signed byte (8 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(sbyte))
            return il.FluentEmit(OpCodes.Conv_I1);
        // Converts the signed value on the top of the evaluation stack to an unsigned byte (8 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(byte))
            return il.FluentEmit(OpCodes.Conv_U1);
        // Converts the signed value on the top of the evaluation stack to an unsigned short (16 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(ushort) || type == typeof(char))
            return il.FluentEmit(OpCodes.Conv_U2);
        // Converts the signed value on the top of the evaluation stack to a signed short (16 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(short))
            return il.FluentEmit(OpCodes.Conv_I2);
        // Converts the signed value on the top of the evaluation stack to an unsigned integer (32 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(uint))
            return il.FluentEmit(OpCodes.Conv_U4);
        // Converts the signed value on the top of the evaluation stack to a signed integer (32 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(int))
            return il.FluentEmit(OpCodes.Conv_I4);
        // Converts the signed value on the top of the evaluation stack to an unsigned long (64 bit integer) with no overflow check. Pushes an int64 value onto the evaluation stack.
        if (type == typeof(ulong))
            return il.FluentEmit(OpCodes.Conv_U8);
        // Converts the signed value on the top of the evaluation stack to a signed long (64 bit integer) with no overflow check. Pushes an int64 value onto the evaluation stack.
        if (type == typeof(long))
            return il.FluentEmit(OpCodes.Conv_I8);
        // Converts the signed value on the top of the evaluation stack to a single floating (8 bit integer) with no overflow check. Pushes an F value onto the evaluation stack.
        if (type == typeof(float))
            return il.FluentEmit(OpCodes.Conv_R4);
        // Converts the signed value on the top of the evaluation stack to a signed byte (8 bit integer) with no overflow check. Pushes an F value onto the evaluation stack.
        if (type == typeof(double))
            return il.FluentEmit(OpCodes.Conv_R8);
#if NetCore
        if (!type.GetTypeInfo().IsValueType)
#else
        if (!type.IsValueType)
#endif
            return il.FluentEmit(OpCodes.Castclass, type);
        throw new InvalidOperationException(string.Format(Strings.CannotConvert, type.FullName));
    }

    public static ILGenerator Conv<T>(this ILGenerator il) => il.ConvertTo(typeof(T));

#if NetCore || Net45
    public static ILGenerator Conv(this ILGenerator il, TypeInfo type) => il.Conv(type?.AsType());
#endif
}