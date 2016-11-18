using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static readonly MethodInfo GetTypeFromHandle = typeof(Type).GetMethod("GetTypeFromHandle");

    /// <summary>
    ///     Pushes the <see cref="Type" /> of the given type onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to load the <see cref="Type" /> of</param>
    public static ILGenerator TypeOf(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(OpCodes.Ldtoken, type);
        return il.Call(GetTypeFromHandle);
    }

    /// <summary>
    ///     Pushes the <see cref="Type" /> of the given type onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type to load the <see cref="Type" /> of</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator TypeOf<T>(this ILGenerator il) => il.TypeOf(typeof(T));
}