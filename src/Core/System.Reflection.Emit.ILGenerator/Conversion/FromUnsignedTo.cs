using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Attempts to converts the unsigned value on the top of the evaluation stack to the specified value type with overflow check.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The value type to convert to.</param>
    public static ILGenerator FromUnsignedTo(this ILGenerator il, Type type) => il.Conv_Ovf_Un(type);

    /// <summary>
    /// Attempts to converts the unsigned value on the top of the evaluation stack to the specified value type with overflow check.
    /// </summary>
    /// <typeparam name="T">The value type to convert to.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator FromUnsignedTo<T>(this ILGenerator il) where T:struct => il.Conv_Ovf_Un<T>();

#if Net45 || NetCore
    /// <summary>
    /// Attempts to converts the unsigned value on the top of the evaluation stack to the specified value type with overflow check.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The value type to convert to.</param>
    public static ILGenerator FromUnsignedTo(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv_Ovf_Un(type);
#endif
}