using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to unbox to</param>
    public static ILGenerator Unbox_Any(this ILGenerator il, Type type)
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
            throw new InvalidOperationException("Cannot unbox.any a non-value type");
        return il.FluentEmit(OpCodes.Unbox_Any, type);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <typeparam name="T">The type to unbox to</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Unbox_Any<T>(this ILGenerator il) => il.Unbox_Any(typeof(T));

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to unbox to</param>
    public static ILGenerator Unbox_Any(this ILGenerator il, TypeInfo type) => il.Unbox_Any(type?.AsType());
#endif
}