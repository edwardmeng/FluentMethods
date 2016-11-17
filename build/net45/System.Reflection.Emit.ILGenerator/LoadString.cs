using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pushes the given string onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The string to push onto the evaluation stack.</param>
    public static ILGenerator LoadString(this ILGenerator il, string value)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        il.Emit(OpCodes.Ldstr, value);
        return il;
    }
}