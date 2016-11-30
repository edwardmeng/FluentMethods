using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes the address of the given local onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to get the address of</param>
    public static ILGenerator LoadLocalAddress(this ILGenerator il, LocalBuilder local) => il.Ldloca(local);
}