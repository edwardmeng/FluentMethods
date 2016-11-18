using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes the number of bytes required to store the given type, for reference types this will always be the size of a
    ///     reference, not the size of an object of that type itself
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to get the size of</param>
    public static ILGenerator SizeOf(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(OpCodes.Sizeof, type);
        return il;
    }

    /// <summary>
    ///     Pushes the number of bytes required to store the given type, for reference types this will always be the size of a
    ///     reference, not the size of an object of that type itself
    /// </summary>
    /// <typeparam name="T">The type to get the size of</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator SizeOf<T>(this ILGenerator il) => il.SizeOf(typeof(T));
}