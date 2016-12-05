using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer off the evaluation stack and creates an array of the given type with that length, pushing the
    ///     reference onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the array</param>
    public static ILGenerator NewArray(this ILGenerator il, Type type) => il.Newarr(type);

    /// <summary>
    ///     Pops an integer off the evaluation stack and creates an array of the given type with that length, pushing the
    ///     reference onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type of the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator NewArray<T>(this ILGenerator il) => il.Newarr<T>();

    /// <summary>
    ///     Creates an array of the given type with the given length, pushing the reference onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the array</param>
    /// <param name="length">The length of the array</param>
    public static ILGenerator NewArray(this ILGenerator il, Type type, uint length) => il.Newarr(type, length);

    /// <summary>
    ///     Creates an array of the given type with the given length, pushing the reference onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type of the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="length">The length of the array</param>
    public static ILGenerator NewArray<T>(this ILGenerator il, uint length) => il.Newarr<T>(length);

#if NetCore || Net45

    /// <summary>
    ///     Pops an integer off the evaluation stack and creates an array of the given type with that length, pushing the
    ///     reference onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the array</param>
    public static ILGenerator NewArray(this ILGenerator il, System.Reflection.TypeInfo type) => il.Newarr(type);

    /// <summary>
    ///     Creates an array of the given type with the given length, pushing the reference onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the array</param>
    /// <param name="length">The length of the array</param>
    public static ILGenerator NewArray(this ILGenerator il, System.Reflection.TypeInfo type, uint length) => il.Newarr(type, length);

#endif
}