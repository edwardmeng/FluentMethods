using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes a null reference (type O) onto the evaluation stack.
    /// </summary>
    public static ILGenerator Ldnull(this ILGenerator il) => il.FluentEmit(OpCodes.Ldnull);
}