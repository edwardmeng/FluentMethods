using FluentMethods;
using System;
using System.Reflection;
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
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        if (!type.GetTypeInfo().IsValueType)
#else
        if (!type.IsValueType)
#endif
            throw new InvalidOperationException(string.Format(Strings.CannotInitialize, type.FullName));

        return il.FluentEmit(OpCodes.Initobj, type);
    }

    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <typeparam name="T">The type to initialize</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Initobj<T>(this ILGenerator il) where T : struct => il.Initobj(typeof(T));

#if Net45 || NetCore
    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <param name="type">The type to initialize</param>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Initobj(this ILGenerator il, TypeInfo type) => il.Initobj(type?.AsType());
#endif
}