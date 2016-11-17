using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes the element at that array index
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator LoadElement(this ILGenerator il, Type type)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (!type.IsValueType)
        {
            il.Emit(OpCodes.Ldelem_Ref);
        }
        else if (type == typeof(sbyte) || type == typeof(bool))
        {
            il.Emit(OpCodes.Ldelem_I1);
        }
        else if (type == typeof(byte))
        {
            il.Emit(OpCodes.Ldelem_U1);
        }
        else if (type == typeof(short))
        {
            il.Emit(OpCodes.Ldelem_I2);
        }
        else if (type == typeof(ushort))
        {
            il.Emit(OpCodes.Ldelem_U2);
        }
        else if (type == typeof(int))
        {
            il.Emit(OpCodes.Ldelem_I4);
        }
        else if (type == typeof(uint))
        {
            il.Emit(OpCodes.Ldelem_U4);
        }
        else if (type == typeof(long))
        {
            il.Emit(OpCodes.Ldelem_I8);
        }
        else if (type == typeof(ulong))
        {
            // Not a mistake! ldelem.U8 is an alias for ldelem.I8
            il.Emit(OpCodes.Ldelem_I8);
        }
        else if (type == typeof(float))
        {
            il.Emit(OpCodes.Ldelem_R4);
        }
        else if (type == typeof(double))
        {
            il.Emit(OpCodes.Ldelem_R8);
        }
        else
        {
            il.Emit(OpCodes.Ldelem, type);
        }
        return il;
    }

    /// <summary>
    /// Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes the element at that array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator LoadElement<T>(this ILGenerator il) => il.LoadElement(typeof(T));

    /// <summary>
    /// Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at the given array index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator LoadElement(this ILGenerator il, Type type, uint index)
    {
        return il.LoadConst(index).LoadElement(type);
    }

    /// <summary>
    /// Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at the given array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator LoadElement<T>(this ILGenerator il, uint index) => il.LoadElement(typeof(T), index);

}