using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops an array reference (containing elements of the given type), and index and a value of the given type, and
    ///     stores the value in the array at that index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator StoreElement(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        if (!type.IsValueType)
            il.Emit(OpCodes.Stelem_Ref);
        else if ((type == typeof(sbyte)) || (type == typeof(byte)) || (type == typeof(bool)))
            il.Emit(OpCodes.Stelem_I1);
        else if ((type == typeof(short)) || (type == typeof(ushort)))
            il.Emit(OpCodes.Stelem_I2);
        else if ((type == typeof(int)) || (type == typeof(uint)))
            il.Emit(OpCodes.Stelem_I4);
        else if ((type == typeof(long)) || (type == typeof(ulong)))
            il.Emit(OpCodes.Ldelem_I8);
        else if (type == typeof(float))
            il.Emit(OpCodes.Stelem_R4);
        else if (type == typeof(double))
            il.Emit(OpCodes.Stelem_R8);
        else
            il.Emit(OpCodes.Stelem, type);
        return il;
    }

    /// <summary>
    ///     Pops an array reference (containing elements of the given type), and index and a value of the given type, and
    ///     stores the value in the array at that index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator StoreElement<T>(this ILGenerator il) => il.StoreElement(typeof(T));

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="bool" />), and stores the given
    ///     <see cref="bool" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="bool" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, bool value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<bool>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="char" />), and stores the given
    ///     <see cref="char" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="char" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, char value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<char>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="sbyte" />), and stores the given
    ///     <see cref="sbyte" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="sbyte" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, sbyte value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<sbyte>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="byte" />), and stores the given
    ///     <see cref="byte" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="byte" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, byte value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<byte>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="short" />), and stores the given
    ///     <see cref="short" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="short" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, short value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<short>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="ushort" />), and stores the given
    ///     <see cref="ushort" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="ushort" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, ushort value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<ushort>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="int" />), and stores the given
    ///     <see cref="int" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="int" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, int value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<int>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="uint" />), and stores the given
    ///     <see cref="uint" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="uint" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, uint value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<uint>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="long" />), and stores the given
    ///     <see cref="long" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="long" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, long value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<long>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="ulong" />), and stores the given
    ///     <see cref="ulong" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="ulong" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, ulong value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<ulong>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="float" />), and stores the given
    ///     <see cref="float" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="float" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, float value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<float>();
    }

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="double" />), and stores the given
    ///     <see cref="double" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="double" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator StoreElement(this ILGenerator il, uint index, double value)
    {
        return il.LoadConst(index).LoadConst(value).StoreElement<double>();
    }
}