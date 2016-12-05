using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the address of the boxed value type of the given type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the boxed value type</param>
    public static ILGenerator Unbox(this ILGenerator il, Type type)
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
            throw new InvalidOperationException("Cannot unbox a non-value type");
        return il.FluentEmit(OpCodes.Unbox, type);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the address of the boxed value type of the given type
    /// </summary>
    /// <typeparam name="T">The type of the boxed value type</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Unbox<T>(this ILGenerator il) => il.Unbox(typeof(T));

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference from the evaluation stack, and pushes the address of the boxed value type of the given type
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the boxed value type</param>
    public static ILGenerator Unbox(this ILGenerator il, TypeInfo type) => il.Unbox(type?.AsType());
#endif
}

