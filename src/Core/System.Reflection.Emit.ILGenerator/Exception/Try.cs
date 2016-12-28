using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Encapsulate the code block for the exception handling purpose.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns>The scope instance to encapsulate the exception handling code block.</returns>
    public static ILGeneratorScope Try(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.BeginExceptionBlock();
        return new ILGeneratorScope(il, il.EndExceptionBlock);
    }
}