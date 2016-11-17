using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator ConvertToChecked(this ILGenerator il, Type type)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        // Converts the signed value on the top of the evaluation stack to a signed byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        if (type == typeof(sbyte))
        {
            il.Emit(OpCodes.Conv_Ovf_U1);
        }
        // Converts the signed value on the top of the evaluation stack to an unsigned byte (8 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(byte))
        {
            il.Emit(OpCodes.Conv_Ovf_I1);
        }
        // Converts the signed value on the top of the evaluation stack to an unsigned short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(ushort))
        {
            il.Emit(OpCodes.Conv_Ovf_U2);
        }
        // Converts the signed value on the top of the evaluation stack to a signed short (16 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(short))
        {
            il.Emit(OpCodes.Conv_Ovf_I2);
        }
        // Converts the signed value on the top of the evaluation stack to an unsigned integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(uint))
        {
            il.Emit(OpCodes.Conv_Ovf_U4);
        }
        // Converts the signed value on the top of the evaluation stack to a signed integer (32 bit integer) with an overflow check. Pushes an int32 value onto the evaluation stack.
        else if (type == typeof(int))
        {
            il.Emit(OpCodes.Conv_Ovf_I4);
        }
        // Converts the signed value on the top of the evaluation stack to an unsigned long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        else if (type == typeof(ulong))
        {
            il.Emit(OpCodes.Conv_Ovf_U8);
        }
        // Converts the signed value on the top of the evaluation stack to a signed long (64 bit integer) with an overflow check. Pushes an int64 value onto the evaluation stack.
        else if (type == typeof(long))
        {
            il.Emit(OpCodes.Conv_Ovf_I8);
        }
        else
        {
            throw new NotSupportedException(string.Format("The type {0} is not supported for the {1} operation.", type, "ConvertToChecked"));
        }
        return il;
    }

    public static ILGenerator ConvertToChecked<T>(this ILGenerator il)
    {
        return il.ConvertToChecked(typeof(T));
    }
}