using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes a reference of the given type if the object is an instance
    ///     of that type, otherwise the null reference is pushed
    /// </summary>
    /// <typeparam name="T">The type to attempt to cast to</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator IsInstanceOf<T>(this ILGenerator il) => il.IsInstanceOf(typeof(T));

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes a reference of the given type if the object is an instance
    ///     of the given type, otherwise the null reference is pushed
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to attempt to cast to</param>
    public static ILGenerator IsInstanceOf(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(OpCodes.Isinst, type);
        return il;
    }
}