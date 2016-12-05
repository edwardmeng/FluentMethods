using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Converts a value type to an object reference (type O).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the value type object</param>
    public static ILGenerator Box(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        if (!type.GetTypeInfo().IsValueType)
#else
        if (!type.IsValueType)
#endif
            throw new InvalidOperationException("Cannot box a non-value type");
        return il.FluentEmit(OpCodes.Box, type);
    }

    /// <summary>
    ///     Converts a value type to an object reference (type O).
    /// </summary>
    /// <typeparam name="T">The type of the value type object</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Box<T>(this ILGenerator il) => il.Box(typeof(T));

#if Net45 || NetCore
    /// <summary>
    ///     Converts a value type to an object reference (type O).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the value type object</param>
    public static ILGenerator Box(this ILGenerator il, TypeInfo type) => il.Box(type?.AsType());
#endif
}