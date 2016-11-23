using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int16.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, short value)
    {
        return il.LoadConst((int) value).ConvertTo<short>();
    }

    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int16.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, ushort value)
    {
        return il.LoadConst((int)value).ConvertTo<ushort>();
    }

    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int32.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, int value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        switch (value)
        {
            case -1:
                il.Emit(OpCodes.Ldc_I4_M1);
                return il;
            case 0:
                il.Emit(OpCodes.Ldc_I4_0);
                return il;
            case 1:
                il.Emit(OpCodes.Ldc_I4_1);
                return il;
            case 2:
                il.Emit(OpCodes.Ldc_I4_2);
                return il;
            case 3:
                il.Emit(OpCodes.Ldc_I4_3);
                return il;
            case 4:
                il.Emit(OpCodes.Ldc_I4_4);
                return il;
            case 5:
                il.Emit(OpCodes.Ldc_I4_5);
                return il;
            case 6:
                il.Emit(OpCodes.Ldc_I4_6);
                return il;
            case 7:
                il.Emit(OpCodes.Ldc_I4_7);
                return il;
            case 8:
                il.Emit(OpCodes.Ldc_I4_8);
                return il;
        }

        if ((value >= -128) && (value < 128))
            il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
        else
            il.Emit(OpCodes.Ldc_I4, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type UInt32 onto the evaluation stack as an int32.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, uint value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (value < int.MaxValue)
            il.LoadConst((int)value);
        else
            il.Emit(OpCodes.Ldc_I4, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type Int64 onto the evaluation stack as an int64.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, long value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if ((value <= int.MaxValue) && (value >= int.MinValue))
            il.LoadConst((int)value).ConvertTo<long>();
        else
            il.Emit(OpCodes.Ldc_I8, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type UInt64 onto the evaluation stack as an int64.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, ulong value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (value <= long.MaxValue)
            il.LoadConst((long)value).ConvertTo<ulong>();
        else
        {
            il.Emit(OpCodes.Ldc_I8, (long)value);
            il.ConvertTo<ulong>();
        }
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type float onto the evaluation stack as type F (float).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, float value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Ldc_R4, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type double onto the evaluation stack as type F (float).
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, double value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Ldc_R8, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type boolean onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, bool value)
    {
        return il.LoadConst(value ? 1 : 0);
    }

    /// <summary>
    ///     Pushes a supplied value of type char onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, char value)
    {
        return il.LoadConst((int)value).ConvertTo<char>();
    }

    /// <summary>
    ///     Pushes a supplied value of type byte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, byte value)
    {
        return il.LoadConst((int)value).ConvertTo<byte>();
    }

    /// <summary>
    ///     Pushes a supplied value of type sbyte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, sbyte value)
    {
        return il.LoadConst((int)value).ConvertTo<sbyte>();
    }

    /// <summary>
    ///     Pushes a supplied value of type string onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, string value)
    {
        return il.LoadString(value);
    }

    /// <summary>
    ///     Pushes a supplied value of type decimal onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, decimal value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (decimal.Truncate(value) == value)
        {
            if ((int.MinValue <= value) && (value <= int.MaxValue))
                return il.LoadConst(decimal.ToInt32(value)).New(typeof(decimal).GetConstructor(new[] { typeof(int) }));
            if ((long.MinValue <= value) && (value <= long.MaxValue))
                return il.LoadConst(decimal.ToInt64(value)).New(typeof(decimal).GetConstructor(new[] { typeof(long) }));
        }
        var bits = decimal.GetBits(value);
        return il
            .LoadConst(bits[0])
            .LoadConst(bits[1])
            .LoadConst(bits[2])
            .LoadConst((bits[3] & 0x80000000L) > 0L)
            .LoadConst((byte)(bits[3] >> 0x10))
            .New(typeof(decimal).GetConstructor(new[] { typeof(int), typeof(int), typeof(int), typeof(bool), typeof(byte) }));
    }

    /// <summary>
    ///     Pushes a supplied value of type <see cref="DateTime"/> onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator LoadConst(this ILGenerator il, DateTime value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.LoadConst(value.Ticks).New(typeof(DateTime).GetConstructor(new[] { typeof(long) }));
    }

    private static ILGenerator LoadConst<T>(this ILGenerator il, T value)
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Boolean:
                return il.LoadConst((bool)(object)value);
            case TypeCode.Char:
                return il.LoadConst((char)(object)value);
            case TypeCode.Byte:
                return il.LoadConst((byte)(object)value);
            case TypeCode.SByte:
                return il.LoadConst((sbyte)(object)value);
            case TypeCode.Int16:
                return il.LoadConst((short)(object)value);
            case TypeCode.UInt16:
                return il.LoadConst((ushort)(object)value);
            case TypeCode.Int32:
                return il.LoadConst((int)(object)value);
            case TypeCode.UInt32:
                return il.LoadConst((uint)(object)value);
            case TypeCode.Int64:
                return il.LoadConst((long)(object)value);
            case TypeCode.UInt64:
                return il.LoadConst((ulong)(object)value);
            case TypeCode.Single:
                return il.LoadConst((float)(object)value);
            case TypeCode.Double:
                return il.LoadConst((double)(object)value);
            case TypeCode.String:
                return il.LoadConst((string)(object)value);
            case TypeCode.Decimal:
                return il.LoadConst((decimal)(object)value);
            case TypeCode.DateTime:
                return il.LoadConst((DateTime)(object)value);
            default:
                throw new NotSupportedException();
        }
    }
}