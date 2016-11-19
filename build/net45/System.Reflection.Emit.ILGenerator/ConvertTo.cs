using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator ConvertTo(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        // Converts the signed value on the top of the evaluation stack to a signed byte (8 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(sbyte))
            il.Emit(OpCodes.Conv_I1);
        // Converts the signed value on the top of the evaluation stack to an unsigned byte (8 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(byte))
            il.Emit(OpCodes.Conv_U1);
        // Converts the signed value on the top of the evaluation stack to an unsigned short (16 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(ushort)|| type == typeof(char))
            il.Emit(OpCodes.Conv_U2);
        // Converts the signed value on the top of the evaluation stack to a signed short (16 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(short))
            il.Emit(OpCodes.Conv_I2);
        // Converts the signed value on the top of the evaluation stack to an unsigned integer (32 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(uint))
            il.Emit(OpCodes.Conv_U4);
        // Converts the signed value on the top of the evaluation stack to a signed integer (32 bit integer) with no overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(int))
            il.Emit(OpCodes.Conv_I4);
        // Converts the signed value on the top of the evaluation stack to an unsigned long (64 bit integer) with no overflow check. Pushes an int64 value onto the evaluation stack.
        else if (type == typeof(ulong))
            il.Emit(OpCodes.Conv_U8);
        // Converts the signed value on the top of the evaluation stack to a signed long (64 bit integer) with no overflow check. Pushes an int64 value onto the evaluation stack.
        else if (type == typeof(long))
            il.Emit(OpCodes.Conv_I8);
        // Converts the signed value on the top of the evaluation stack to a single floating (8 bit integer) with no overflow check. Pushes an F value onto the evaluation stack.
        else if (type == typeof(float))
            il.Emit(OpCodes.Conv_R4);
        // Converts the signed value on the top of the evaluation stack to a signed byte (8 bit integer) with no overflow check. Pushes an F value onto the evaluation stack.
        else if (type == typeof(double))
            il.Emit(OpCodes.Conv_R8);
        else if (!type.IsValueType)
            il.Emit(OpCodes.Castclass, type);
        return il;
    }

    public static ILGenerator ConvertTo<T>(this ILGenerator il)
    {
        return il.ConvertTo(typeof(T));
    }
}