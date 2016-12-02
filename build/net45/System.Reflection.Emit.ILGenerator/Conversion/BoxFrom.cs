using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Converts a value type to an object reference (type O).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the value type object</param>
    public static ILGenerator BoxFrom(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return type.IsValueType ? il.Box(type) : il.Castclass(type);
    }

    /// <summary>
    ///     Converts a value type to an object reference (type O).
    /// </summary>
    /// <typeparam name="T">The type of the value type object</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator BoxFrom<T>(this ILGenerator il) => il.BoxFrom(typeof(T));
}