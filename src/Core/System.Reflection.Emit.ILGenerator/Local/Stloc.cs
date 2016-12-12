using FluentMethods;
using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a value from the evaluation stack and stores it in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store the evaluation stack value in</param>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local)
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

    private static ILGenerator Stloc<T>(this ILGenerator il, LocalBuilder local, T value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(T))
            throw new ArgumentException(string.Format(Strings.CannotStoreLocal, typeof(T).FullName, local.LocalType.FullName));

        return il.Ldc(value).Stloc(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Boolean" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, bool value) => il.Stloc<bool>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Char" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, char value) => il.Stloc<char>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="SByte" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, sbyte value) => il.Stloc<sbyte>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Byte" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, byte value) => il.Stloc<byte>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int16" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, short value) => il.Stloc<short>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt16" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, ushort value) => il.Stloc<ushort>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int32" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, int value) => il.Stloc<int>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt32" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, uint value) => il.Stloc<uint>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int64" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, long value) => il.Stloc<long>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt64" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, ulong value) => il.Stloc<ulong>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Single" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, float value) => il.Stloc<float>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, double value) => il.Stloc<double>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, string value) => il.Stloc<string>(local, value);

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator Stloc(this ILGenerator il, LocalBuilder local, decimal value) => il.Stloc<decimal>(local, value);
}