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
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        switch (local.LocalIndex)
        {
            case 0:
                return il.FluentEmit(OpCodes.Stloc_0);
            case 1:
                return il.FluentEmit(OpCodes.Stloc_1);
            case 2:
                return il.FluentEmit(OpCodes.Stloc_2);
            default:
                return il.FluentEmit(local.LocalIndex <= 255 ? OpCodes.Stloc_S : OpCodes.Stloc, local);
        }
    }

    private static ILGenerator StoreLocal<T>(this ILGenerator il, LocalBuilder local, T value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(T))
            throw new ArgumentException($"Cannot store a {typeof(T).Name} value in a local of type {local.LocalType.Name}.");

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Boolean" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, bool value) => il.StoreLocal<bool>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Char" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, char value) => il.StoreLocal<char>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="SByte" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, sbyte value) => il.StoreLocal<sbyte>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Byte" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, byte value) => il.StoreLocal<byte>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, short value) => il.StoreLocal<short>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, ushort value) => il.StoreLocal<ushort>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, int value) => il.StoreLocal<int>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, uint value) => il.StoreLocal<uint>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, long value) => il.StoreLocal<long>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, ulong value) => il.StoreLocal<ulong>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, float value) => il.StoreLocal<float>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, double value) => il.StoreLocal<double>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, string value) => il.StoreLocal<string>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, decimal value) => il.StoreLocal<decimal>(local, value);
}