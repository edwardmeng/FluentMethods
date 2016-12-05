using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a value from the evaluation stack and returns it to the calling method
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Ret(this ILGenerator il) => il.FluentEmit(OpCodes.Ret);
}