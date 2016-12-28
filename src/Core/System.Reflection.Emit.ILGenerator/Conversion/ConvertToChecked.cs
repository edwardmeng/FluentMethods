using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Attempts to convert the value on the top of the evaluation stack to the specified value type with overflow check.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The value type to convert to.</param>
    public static ILGenerator ConvertToChecked(this ILGenerator il, Type type) => il.Conv_Ovf(type);

    /// <summary>
    ///     Attempts to convert the value on the top of the evaluation stack to the specified value type with overflow check.
    /// </summary>
    /// <typeparam name="T">The value type to convert to.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    public static ILGenerator ConvertToChecked<T>(this ILGenerator il) => il.Conv_Ovf<T>();

#if Net45 || NetCore
    /// <summary>
    ///     Attempts to convert the value on the top of the evaluation stack to the specified value type with overflow check.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The value type to convert to.</param>
    public static ILGenerator ConvertToChecked(this ILGenerator il, System.Reflection.TypeInfo type) => il.Conv_Ovf(type);
#endif
}