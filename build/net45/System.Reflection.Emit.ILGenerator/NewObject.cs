using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Creates a new object or instance of a value type, calling the given constructor (and popping the requisite
    ///     arguments from the evaluation stack) and pushing the reference or value (respectively) onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of object/value type to create</param>
    public static ILGenerator NewObject(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
        return il;
    }

    /// <summary>
    ///     Creates a new object or instance of a value type, calling the default constructor and pushing the reference or
    ///     value (respectively) onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type of object/value type to create</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator NewObject<T>(this ILGenerator il) where T : class, new()
    {
        return il.NewObject(typeof(T));
    }
}