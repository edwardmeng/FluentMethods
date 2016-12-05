using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Duplicates the value on the top of the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Duplicate(this ILGenerator il) => il.Dup();
}