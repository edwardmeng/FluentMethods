using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an integer value from the evaluation stack and branches to the corresponding zero-indexed label in the
    ///     provided list, continuing to the next instruction if the value is outside the valid range
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="labels">The labels to form a jump table from</param>
    public static ILGenerator Switch(this ILGenerator il, params Label[] labels)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Switch, labels);
        return il;
    }
}