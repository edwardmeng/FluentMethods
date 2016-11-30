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
    public static ILGenerator Ldelema(this ILGenerator il, Type type) => il.FluentEmit(OpCodes.Ldelema, type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at that array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Ldelema<T>(this ILGenerator il) => il.Ldelema(typeof(T));

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and pushes the address of the element at the given
    ///     index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator Ldelema(this ILGenerator il, Type type, uint index) => il.Ldc(index).Ldelema(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the address of
    ///     the element at the given index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator Ldelema<T>(this ILGenerator il, uint index) => il.Ldelema(typeof(T), index);
}