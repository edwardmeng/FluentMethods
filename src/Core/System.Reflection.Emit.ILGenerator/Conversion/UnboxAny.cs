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
    public static ILGenerator UnboxAny(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        var reflectingType = type.GetTypeInfo();
#else
        var reflectingType = type;
#endif
        return reflectingType.IsValueType ? il.Unbox_Any(reflectingType) : il.Castclass(reflectingType);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <typeparam name="T">The type to unbox to</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator UnboxAny<T>(this ILGenerator il) => il.UnboxAny(typeof(T));

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the value type object if the object is a boxed value type,
    ///     or a reference of the given type if the object is a reference type and is an instance of that type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to unbox to</param>
    public static ILGenerator UnboxAny(this ILGenerator il, TypeInfo type) => il.UnboxAny(type?.AsType());
#endif
}