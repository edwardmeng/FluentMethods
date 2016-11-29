using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the element at that array index
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator Ldelem(this ILGenerator il, Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        if (!type.IsValueType)
            return il.FluentEmit(OpCodes.Ldelem_Ref);
        if ((type == typeof(sbyte)) || (type == typeof(bool)))
            return il.FluentEmit(OpCodes.Ldelem_I1);
        if (type == typeof(byte))
            return il.FluentEmit(OpCodes.Ldelem_U1);
        if (type == typeof(short))
            return il.FluentEmit(OpCodes.Ldelem_I2);
        if (type == typeof(ushort) || type == typeof(char))
            return il.FluentEmit(OpCodes.Ldelem_U2);
        if (type == typeof(int))
            return il.FluentEmit(OpCodes.Ldelem_I4);
        if (type == typeof(uint))
            return il.FluentEmit(OpCodes.Ldelem_U4);
        if (type == typeof(long))
            return il.FluentEmit(OpCodes.Ldelem_I8);
        if (type == typeof(ulong))
            return il.FluentEmit(OpCodes.Ldelem_I8);
        if (type == typeof(float))
            return il.FluentEmit(OpCodes.Ldelem_R4);
        if (type == typeof(double))
            return il.FluentEmit(OpCodes.Ldelem_R8);
        return il.FluentEmit(OpCodes.Ldelem, type);
    }

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the element at that array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Ldelem<T>(this ILGenerator il) => il.Ldelem(typeof(T));

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at
    ///     the given array index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator Ldelem(this ILGenerator il, Type type, uint index) => il.LoadConst(index).Ldelem(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at
    ///     the given array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator Ldelem<T>(this ILGenerator il, uint index) => il.Ldelem(typeof(T), index);
}