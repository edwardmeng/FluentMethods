using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Stelem<T>(this ILGenerator il, uint index, T value) => il.Ldc(index).Ldc(value).Stelem<T>();

    /// <summary>
    ///     Pops an array reference (containing elements of the given type), and index and a value of the given type, and
    ///     stores the value in the array at that index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator Stelem(this ILGenerator il, Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        if (!type.IsValueType)
            return il.FluentEmit(OpCodes.Stelem_Ref);
        if ((type == typeof(sbyte)) || (type == typeof(byte)) || (type == typeof(bool)))
            return il.FluentEmit(OpCodes.Stelem_I1);
        if ((type == typeof(short)) || (type == typeof(ushort)))
            return il.FluentEmit(OpCodes.Stelem_I2);
        if ((type == typeof(int)) || (type == typeof(uint)))
            return il.FluentEmit(OpCodes.Stelem_I4);
        if ((type == typeof(long)) || (type == typeof(ulong)))
            return il.FluentEmit(OpCodes.Stelem_I8);
        if (type == typeof(float))
            return il.FluentEmit(OpCodes.Stelem_R4);
        if (type == typeof(double))
            return il.FluentEmit(OpCodes.Stelem_R8);
        return il.FluentEmit(OpCodes.Stelem, type);
    }

    /// <summary>
    ///     Pops an array reference (containing elements of the given type), and index and a value of the given type, and
    ///     stores the value in the array at that index
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Stelem<T>(this ILGenerator il) => il.Stelem(typeof(T));

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="bool" />), and stores the given
    ///     <see cref="bool" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="bool" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, bool value) => il.Stelem<bool>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="char" />), and stores the given
    ///     <see cref="char" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="char" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, char value) => il.Stelem<char>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="sbyte" />), and stores the given
    ///     <see cref="sbyte" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="sbyte" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, sbyte value) => il.Stelem<sbyte>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="byte" />), and stores the given
    ///     <see cref="byte" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="byte" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, byte value) => il.Stelem<byte>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="short" />), and stores the given
    ///     <see cref="short" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="short" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, short value) => il.Stelem<short>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="ushort" />), and stores the given
    ///     <see cref="ushort" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="ushort" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, ushort value) => il.Stelem<ushort>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="int" />), and stores the given
    ///     <see cref="int" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="int" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, int value) => il.Stelem<int>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="uint" />), and stores the given
    ///     <see cref="uint" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="uint" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, uint value) => il.Stelem<uint>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="long" />), and stores the given
    ///     <see cref="long" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="long" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, long value) => il.Stelem<long>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="ulong" />), and stores the given
    ///     <see cref="ulong" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="ulong" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, ulong value) => il.Stelem<ulong>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="float" />), and stores the given
    ///     <see cref="float" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="float" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, float value) => il.Stelem<float>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="double" />), and stores the given
    ///     <see cref="double" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="double" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, double value) => il.Stelem<double>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="decimal" />), and stores the given
    ///     <see cref="decimal" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="decimal" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, decimal value) => il.Stelem<decimal>(index, value);

    /// <summary>
    ///     Pops an array reference (containing elements of <see cref="string" />), and stores the given
    ///     <see cref="string" /> value at the given index
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The <see cref="string" /> value to store in the array</param>
    /// <param name="index">The index to store the value at</param>
    public static ILGenerator Stelem(this ILGenerator il, uint index, string value) => il.Stelem<string>(index, value);
}