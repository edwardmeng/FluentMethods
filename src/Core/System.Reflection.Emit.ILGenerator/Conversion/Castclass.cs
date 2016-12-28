using System;
using System.Reflection;
using System.Reflection.Emit;
using FluentMethods;

public static partial class Extensions
{
    /// <summary>
    ///     Attempts to cast an object passed by reference to the specified class.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the specified class.</param>
    public static ILGenerator Castclass(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        if (type.GetTypeInfo().IsValueType)
#else
        if (type.IsValueType)
#endif
            throw new InvalidOperationException(string.Format(Strings.CannotCast, type.FullName));
        return il.FluentEmit(OpCodes.Castclass, type);
    }

    /// <summary>
    ///     Attempts to cast an object passed by reference to the specified class.
    /// </summary>
    /// <typeparam name="T">The type of the specified class.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Castclass<T>(this ILGenerator il) => il.Castclass(typeof(T));

#if NetCore || Net45
    /// <summary>
    ///     Attempts to cast an object passed by reference to the specified class.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the specified class.</param>
    public static ILGenerator Castclass(this ILGenerator il, TypeInfo type) => il.Castclass(type?.AsType());
#endif
}