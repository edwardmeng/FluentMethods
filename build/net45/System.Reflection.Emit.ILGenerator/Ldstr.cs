using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes the given string onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The string to push onto the evaluation stack.</param>
    public static ILGenerator Ldstr(this ILGenerator il, string value) 
        => value == null ? il.FluentEmit(OpCodes.Ldnull) : il.FluentEmit(OpCodes.Ldstr, value);
}