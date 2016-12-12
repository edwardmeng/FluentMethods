using System;
using System.Reflection.Emit;
using FluentMethods;

public static partial class Extensions
{
    public static ILGenerator Conv_Ovf(this ILGenerator il, Type type)
    {
        // Converts the signed value on the top of the evaluation stack to a signed byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(sbyte))
            return il.FluentEmit(OpCodes.Conv_Ovf_I1);
        // Converts the signed value on the top of the evaluation stack to an unsigned byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(byte))
            return il.FluentEmit(OpCodes.Conv_Ovf_U1);
        // Converts the signed value on the top of the evaluation stack to an unsigned short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(ushort) || type == typeof(char))
            return il.FluentEmit(OpCodes.Conv_Ovf_U2);
        // Converts the signed value on the top of the evaluation stack to a signed short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(short))
            return il.FluentEmit(OpCodes.Conv_Ovf_I2);
        // Converts the signed value on the top of the evaluation stack to an unsigned integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(uint))
            return il.FluentEmit(OpCodes.Conv_Ovf_U4);
        // Converts the signed value on the top of the evaluation stack to a signed integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(int))
            return il.FluentEmit(OpCodes.Conv_Ovf_I4);
        // Converts the signed value on the top of the evaluation stack to an unsigned long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        if (type == typeof(ulong))
            return il.FluentEmit(OpCodes.Conv_Ovf_U8);
        // Converts the signed value on the top of the evaluation stack to a signed long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        if (type == typeof(long))
            return il.FluentEmit(OpCodes.Conv_Ovf_I8);
        throw new NotSupportedException(string.Format(Strings.CannotConvertChecked, type));
    }

    public static ILGenerator Conv_Ovf<T>(this ILGenerator il) => il.Conv_Ovf(typeof(T));

#if Net45 || NetCore
    public static ILGenerator Conv_Ovf(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv_Ovf(type?.AsType());
#endif
}