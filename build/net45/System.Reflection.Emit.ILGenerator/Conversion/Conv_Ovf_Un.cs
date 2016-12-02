using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator Conv_Ovf_Un(this ILGenerator il, Type type)
    {
        // Converts the unsigned value on the top of the evaluation stack to a signed byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(sbyte))
            return il.FluentEmit(OpCodes.Conv_Ovf_U1_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(byte))
            return il.FluentEmit(OpCodes.Conv_Ovf_I1_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(ushort) || type == typeof(char))
            return il.FluentEmit(OpCodes.Conv_Ovf_U2_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(short))
            return il.FluentEmit(OpCodes.Conv_Ovf_I2_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(uint))
            return il.FluentEmit(OpCodes.Conv_Ovf_U4_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(int))
            return il.FluentEmit(OpCodes.Conv_Ovf_I4_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        if (type == typeof(ulong))
            return il.FluentEmit(OpCodes.Conv_Ovf_U8_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        if (type == typeof(long))
            return il.FluentEmit(OpCodes.Conv_Ovf_I8_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed byte (8 bit integer) with an overflow check. Pushes an F value onto the evaluation stack.
        if (type == typeof(double) || type == typeof(float))
            return il.FluentEmit(OpCodes.Conv_R_Un);
        throw new NotSupportedException(string.Format("The type {0} is not supported for the {1} operation.", type, "Conv_Ovf_Un"));
    }

    public static ILGenerator Conv_Ovf_Un<T>(this ILGenerator il) where T : struct => il.Conv_Ovf_Un(typeof(T));
}