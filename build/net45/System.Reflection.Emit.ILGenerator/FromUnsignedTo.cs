using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator FromUnsignedTo(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        // Converts the unsigned value on the top of the evaluation stack to a signed byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(sbyte))
            il.Emit(OpCodes.Conv_Ovf_U1_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(byte))
            il.Emit(OpCodes.Conv_Ovf_I1_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(ushort) || type == typeof(char))
            il.Emit(OpCodes.Conv_Ovf_U2_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(short))
            il.Emit(OpCodes.Conv_Ovf_I2_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(uint))
            il.Emit(OpCodes.Conv_Ovf_U4_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(int))
            il.Emit(OpCodes.Conv_Ovf_I4_Un);
        // Converts the unsigned value on the top of the evaluation stack to an unsigned long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        else if (type == typeof(ulong))
            il.Emit(OpCodes.Conv_Ovf_U8_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        else if (type == typeof(long))
            il.Emit(OpCodes.Conv_Ovf_I8_Un);
        // Converts the unsigned value on the top of the evaluation stack to a signed byte (8 bit integer) with an overflow check. Pushes an F value onto the evaluation stack.
        else if (type == typeof(double)|| type == typeof(float))
            il.Emit(OpCodes.Conv_R_Un);
        else
            throw new NotSupportedException(string.Format("The type {0} is not supported for the {1} operation.", type, "FromUnsignedTo"));
        return il;
    }

    public static ILGenerator FromUnsignedTo<T>(this ILGenerator il) where T:struct
    {
        return il.FromUnsignedTo(typeof(T));
    }
}