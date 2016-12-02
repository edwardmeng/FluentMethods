using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the address of the boxed value type of the given type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the boxed value type</param>
    public static ILGenerator UnboxTo(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return type.IsValueType ? il.Unbox(type) : il.Castclass(type);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the address of the boxed value type of the given type
    /// </summary>
    /// <typeparam name="T">The type of the boxed value type</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator UnboxTo<T>(this ILGenerator il) => il.UnboxTo(typeof(T));
}

