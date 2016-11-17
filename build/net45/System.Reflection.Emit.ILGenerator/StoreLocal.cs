using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops a value from the evaluation stack and stores it in the given local
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
                il.Emit(OpCodes.Stloc_0);
                break;
            case 1:
                il.Emit(OpCodes.Stloc_1);
                break;
            case 2:
                il.Emit(OpCodes.Stloc_2);
                break;
            default:
                il.Emit(local.LocalIndex <= 255 ? OpCodes.Stloc_S : OpCodes.Stloc, local);
                break;
        }
        return il;
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Boolean" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, bool value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(bool))
            throw new ArgumentException("Cannot store a Boolean value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Char" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, char value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(char))
            throw new ArgumentException("Cannot store a Char value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="SByte" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, sbyte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(sbyte))
            throw new ArgumentException("Cannot store a SByte value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Byte" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, byte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(byte))
            throw new ArgumentException("Cannot store a Byte value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, short value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(short))
            throw new ArgumentException("Cannot store a Int16 value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, ushort value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(ushort))
            throw new ArgumentException("Cannot store a UInt16 value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, int value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(int))
            throw new ArgumentException("Cannot store a Int32 value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, uint value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(uint))
            throw new ArgumentException("Cannot store a UInt32 value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, long value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(long))
            throw new ArgumentException("Cannot store a Int64 value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, ulong value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(ulong))
            throw new ArgumentException("Cannot store a UInt64 value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, float value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(float))
            throw new ArgumentException("Cannot store a Single value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }

    /// <summary>
    ///     Stores the given value in the given local
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="local">The local to store value in</param>
    /// <param name="value">The value to store in the local</param>
    /// <exception cref="ArgumentException">Thrown if the local is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreLocal(this ILGenerator il, LocalBuilder local, double value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        if (local.LocalType != typeof(double))
            throw new ArgumentException("Cannot store a Double value in a local of type " + local.LocalType.Name);

        return il.LoadConst(value).StoreLocal(local);
    }
}