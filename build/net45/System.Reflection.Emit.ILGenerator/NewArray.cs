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
    public static ILGenerator NewArray(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(OpCodes.Newarr, type);
        return il;
    }

    /// <summary>
    ///     Pops an integer off the evaluation stack and creates an array of the given type with that length, pushing the
    ///     reference onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type of the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator NewArray<T>(this ILGenerator il) => il.NewArray(typeof(T));

    /// <summary>
    ///     Creates an array of the given type with the given length, pushing the reference onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the array</param>
    /// <param name="length">The length of the array</param>
    public static ILGenerator NewArray(this ILGenerator il, Type type, uint length)
    {
        return il.LoadConst(length).NewArray(type);
    }

    /// <summary>
    ///     Creates an array of the given type with the given length, pushing the reference onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type of the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="length">The length of the array</param>
    public static ILGenerator NewArray<T>(this ILGenerator il, uint length) => il.NewArray(typeof(T), length);
}