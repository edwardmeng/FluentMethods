using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
#if NetCore
    private static readonly MethodInfo GetTypeFromHandle = typeof(Type).GetTypeInfo().GetMethod("GetTypeFromHandle");
#else
    private static readonly MethodInfo GetTypeFromHandle = typeof(Type).GetMethod("GetTypeFromHandle");
#endif

    /// <summary>
    ///     Pushes the <see cref="Type" /> of the given type onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to load the <see cref="Type" /> of</param>
    public static ILGenerator TypeOf(this ILGenerator il, Type type) => il.FluentEmit(OpCodes.Ldtoken, type).Call(GetTypeFromHandle);

    /// <summary>
    ///     Pushes the <see cref="Type" /> of the given type onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type to load the <see cref="Type" /> of</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator TypeOf<T>(this ILGenerator il) => il.TypeOf(typeof(T));

#if Net45 || NetCore
    /// <summary>
    ///     Pushes the <see cref="Type" /> of the given type onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to load the <see cref="Type" /> of</param>
    public static ILGenerator TypeOf(this ILGenerator il, TypeInfo type) => il.TypeOf(type?.AsType());
#endif
}