using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Exits the current method and jumps immediately to the given method, using the same arguments
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to jump to</param>
    public static ILGenerator JumpTo(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        il.Emit(OpCodes.Jmp, method);
        return il;
    }
}