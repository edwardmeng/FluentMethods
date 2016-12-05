using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Loads an argument (referenced by a specified index value) onto the stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the argument to load.</param>
    public static ILGenerator LoadArg(this ILGenerator il, ushort index) => il.Ldarg(index);
}