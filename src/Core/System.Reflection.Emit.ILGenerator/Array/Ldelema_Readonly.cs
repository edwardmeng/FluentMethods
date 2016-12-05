using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at that array index, with restrictions on its use by other code
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator Ldelema_Readonly(this ILGenerator il, Type type) => il.FluentEmit(OpCodes.Readonly).FluentEmit(OpCodes.Ldelema, type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at the given index, with restrictions on its use by other code
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator Ldelema_Readonly(this ILGenerator il, Type type, uint index) => il.Ldc(index).Ldelema_Readonly(type);

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at that array index, with restrictions on its use by other code
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Ldelema_Readonly<T>(this ILGenerator il) => il.Ldelema_Readonly(typeof(T));

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at the given index, with restrictions on its use by other code
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator Ldelema_Readonly<T>(this ILGenerator il, uint index) => il.Ldelema_Readonly(typeof(T), index);

#if Net45 || NetCore
    
    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at that array index, with restrictions on its use by other code
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator Ldelema_Readonly(this ILGenerator il, System.Reflection.TypeInfo type) => il.Ldelema_Readonly(type?.AsType());

    /// <summary>
    ///     Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes
    ///     the address of the element at the given index, with restrictions on its use by other code
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator Ldelema_Readonly(this ILGenerator il, System.Reflection.TypeInfo type, uint index) => il.Ldelema_Readonly(type?.AsType(), index);

#endif
}