using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <param name="type">The type to initialize</param>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Initobj(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        if (!type.IsValueType)
            throw new InvalidOperationException("Cannot initialize a non-value type");

        return il.FluentEmit(OpCodes.Initobj, type);
    }

    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <typeparam name="T">The type to initialize</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Initobj<T>(this ILGenerator il) where T : struct => il.Initobj(typeof(T));
}