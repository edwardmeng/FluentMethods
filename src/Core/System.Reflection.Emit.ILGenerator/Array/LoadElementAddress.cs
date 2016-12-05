using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator LoadElementAddress(this ILGenerator il, Type type) => il.Ldelema(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at that array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator LoadElementAddress<T>(this ILGenerator il) => il.Ldelema<T>();

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and pushes the address of the element at the given
    ///     index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator LoadElementAddress(this ILGenerator il, Type type, uint index) => il.Ldelema(type, index);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the address of
    ///     the element at the given index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator LoadElementAddress<T>(this ILGenerator il, uint index) => il.Ldelema<T>(index);

#if NetCore || Net45

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator LoadElementAddress(this ILGenerator il, System.Reflection.TypeInfo type) => il.Ldelema(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and pushes the address of the element at the given
    ///     index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator LoadElementAddress(this ILGenerator il, System.Reflection.TypeInfo type, uint index) => il.Ldelema(type, index);

#endif
}