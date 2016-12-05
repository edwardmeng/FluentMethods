using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a value from the evaluation stack and stores it in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store the evaluation stack value in</param>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local)
    {
        return il.Stloc(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="bool" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, bool value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="char" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, char value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="sbyte" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, sbyte value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="byte" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, byte value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="short" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, short value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="ushort" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, ushort value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="int" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, int value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="uint" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, uint value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="long" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, long value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="ulong" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, ulong value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="float" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, float value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="double" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, double value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="string" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, string value)
        => il.Stloc(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="decimal" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, decimal value)
        => il.Stloc(local, value);
}