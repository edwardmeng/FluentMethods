using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Encapsulate the fault block of the exception handling.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns>The scope instance to encapsulate the fault block of exception handling.</returns>
    public static ILGeneratorScope Fault(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginFaultBlock();
        return new ILGeneratorScope(il);
    }
}