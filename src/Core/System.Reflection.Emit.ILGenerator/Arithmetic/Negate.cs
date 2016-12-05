using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Negates the integer value on the top of the evaluation stack, with no overflow check
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <remarks>
    ///     If you need to check for overflow (as in the case of int.MinValue), you need to subtract the value from 0 instead.
    /// </remarks>
    public static ILGenerator Negate(this ILGenerator il) => il.Neg();
}