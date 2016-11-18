using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to unbox to</param>
    public static ILGenerator UnboxAny(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
        return il;
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <typeparam name="T">The type to unbox to</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator UnboxAny<T>(this ILGenerator il) => il.UnboxAny(typeof(T));
}