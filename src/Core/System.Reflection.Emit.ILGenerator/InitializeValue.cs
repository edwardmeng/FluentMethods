using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <param name="type">The type to initialize</param>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator InitializeValue(this ILGenerator il, Type type) => il.Initobj(type);

    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <typeparam name="T">The type to initialize</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator InitializeValue<T>(this ILGenerator il) where T : struct => il.Initobj<T>();

#if Net45 || NetCore
    /// <summary>
    ///     Pops the address of the storage location of a value type and initializes each field of the type at that location
    /// </summary>
    /// <param name="type">The type to initialize</param>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator InitializeValue(this ILGenerator il, System.Reflection.TypeInfo type) => il.InitializeValue(type?.AsType());
#endif
}