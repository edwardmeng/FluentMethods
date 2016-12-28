using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Encapsulate the finally block of the exception handling.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns>The scope instance to encapsulate the finally block of exception handling.</returns>
    public static ILGeneratorScope Finally(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginFinallyBlock();
        return new ILGeneratorScope(il);
    }
}