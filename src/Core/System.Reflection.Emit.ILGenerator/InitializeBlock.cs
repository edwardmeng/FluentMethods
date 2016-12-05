using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an address, initialization value and number of bytes off the evaluation stack, and initializes the block of
    ///     memory at the address with the value to that size
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator InitializeBlock(this ILGenerator il) => il.Initblk();

    /// <summary>
    ///     Pops an address off the evaluation stack and initializes the block of memory at the address with the given value to
    ///     the given size
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The initialization value</param>
    /// <param name="bytes">The number of bytes to initialize</param>
    public static ILGenerator InitializeBlock(this ILGenerator il, byte value, uint bytes) => il.Initblk(value, bytes);
}