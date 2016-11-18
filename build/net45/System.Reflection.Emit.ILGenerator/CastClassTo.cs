using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes a reference of the given type if the object is an instance
    ///     of that type, otherwise an <see cref="InvalidCastException" /> is thrown
    /// </summary>
    /// <typeparam name="T">The type to attempt to cast to</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator CastClassTo<T>(this ILGenerator il) where T : class => il.CastClassTo(typeof(T));

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes a reference of the given type if the object is an instance
    ///     of that type, otherwise an <see cref="InvalidCastException" /> is thrown
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to attempt to cast to</param>
    public static ILGenerator CastClassTo(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        if (type.IsValueType)
            throw new InvalidOperationException("Cannot cast to a value type");
        il.Emit(OpCodes.Castclass, type);
        return il;
    }
}