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
    public static ILGenerator LoadElement(this ILGenerator il, Type type) => il.Ldelem(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the element at that array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator LoadElement<T>(this ILGenerator il) => il.Ldelem<T>();

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at
    ///     the given array index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator LoadElement(this ILGenerator il, Type type, uint index) => il.Ldelem(type, index);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at
    ///     the given array index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator LoadElement<T>(this ILGenerator il, uint index) => il.Ldelem<T>(index);

#if Net45 || NetCore

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the element at that array index
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator LoadElement(this ILGenerator il, System.Reflection.TypeInfo type) => il.Ldelem(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) off the evaluation stack and pushes the element at
    ///     the given array index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load</param>
    public static ILGenerator LoadElement(this ILGenerator il, System.Reflection.TypeInfo type, uint index) => il.Ldelem(type, index);

#endif
}