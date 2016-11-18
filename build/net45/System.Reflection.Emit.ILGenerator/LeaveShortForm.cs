using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Branch to the given label, clearing the evaluation stack; can be used to leave a protected region
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="label">The label to branch to</param>
    public static ILGenerator LeaveShortForm(this ILGenerator il, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Leave_S, label);
        return il;
    }
}