using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Attempts to convert an object to the specified type.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to convert to.</param>
    public static ILGenerator ConvertTo(this ILGenerator il, Type type) => il.Conv(type);

    /// <summary>
    ///     Attempts to convert an object to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert to.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns></returns>
    public static ILGenerator ConvertTo<T>(this ILGenerator il) => il.Conv<T>();

#if Net45 || NetCore
    /// <summary>
    ///     Attempts to convert an object to the specified type.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to convert to.</param>
    public static ILGenerator ConvertTo(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv(type);
#endif
}