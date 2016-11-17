using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops an array reference (containing elements of the given type), and index and a value of the given type, and stores the value in the array at that index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator StoreElement(this ILGenerator il, Type type)
    {
        if (!type.IsValueType)
        {
            il.Emit(OpCodes.Stelem_Ref);
        }
        else if (type == typeof(sbyte) || type == typeof(byte) || type == typeof(bool))
        {
            il.Emit(OpCodes.Stelem_I1);
        }
        else if (type == typeof(short) || type == typeof(ushort))
        {
            il.Emit(OpCodes.Stelem_I2);
        }
        else if (type == typeof(int) || type == typeof(uint))
        {
            il.Emit(OpCodes.Stelem_I4);
        }
        else if (type == typeof(long) || type == typeof(ulong))
        {
            il.Emit(OpCodes.Ldelem_I8);
        }
        else if (type == typeof(float))
        {
            il.Emit(OpCodes.Stelem_R4);
        }
        else if (type == typeof(double))
        {
            il.Emit(OpCodes.Stelem_R8);
        }
        else
        {
            il.Emit(OpCodes.Stelem, type);
        }
        return il;
    }

    /// <summary>
    /// Pops an array reference (containing elements of the given type), and index and a value of the given type, and stores the value in the array at that index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator StoreElement<T>(this ILGenerator il) => il.StoreElement(typeof(T));
}