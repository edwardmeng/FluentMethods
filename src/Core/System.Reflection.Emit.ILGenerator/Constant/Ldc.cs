using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int16.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, short value)
    {
        return il.Ldc((int)value).ConvertTo<short>();
    }

    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int16.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, ushort value)
    {
        return il.Ldc((int)value).ConvertTo<ushort>();
    }

    /// <summary>
    ///     Pushes a supplied value of type Int32 onto the evaluation stack as an int32.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, int value)
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
    public static ILGenerator Ldc(this ILGenerator il, uint value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (value < int.MaxValue)
            il.Ldc((int)value);
        else
            il.Emit(OpCodes.Ldc_I4, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type Int64 onto the evaluation stack as an int64.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, long value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if ((value <= int.MaxValue) && (value >= int.MinValue))
            il.Ldc((int)value).ConvertTo<long>();
        else
            il.Emit(OpCodes.Ldc_I8, value);
        return il;
    }

    /// <summary>
    ///     Pushes a supplied value of type UInt64 onto the evaluation stack as an int64.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, ulong value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (value <= long.MaxValue)
            il.Ldc((long)value).ConvertTo<ulong>();
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
    public static ILGenerator Ldc(this ILGenerator il, float value)
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
    public static ILGenerator Ldc(this ILGenerator il, double value)
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
    public static ILGenerator Ldc(this ILGenerator il, bool value)
    {
        return il.Ldc(value ? 1 : 0);
    }

    /// <summary>
    ///     Pushes a supplied value of type char onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, char value)
    {
        return il.Ldc((int)value).ConvertTo<char>();
    }

    /// <summary>
    ///     Pushes a supplied value of type byte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, byte value)
    {
        return il.Ldc((int)value).ConvertTo<byte>();
    }

    /// <summary>
    ///     Pushes a supplied value of type sbyte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, sbyte value)
    {
        return il.Ldc((int)value).ConvertTo<sbyte>();
    }

    /// <summary>
    ///     Pushes a supplied value of type string onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, string value)
    {
        return il.LoadString(value);
    }

    /// <summary>
    ///     Pushes a supplied value of type decimal onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, decimal value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
#if NetCore
        var decimalType = typeof(decimal).GetTypeInfo();
#else
        var decimalType = typeof(decimal);
#endif
        if (decimal.Truncate(value) == value)
        {
            if ((int.MinValue <= value) && (value <= int.MaxValue))
                return il.Ldc(decimal.ToInt32(value)).New(decimalType.GetConstructor(new[] { typeof(int) }));
            if ((long.MinValue <= value) && (value <= long.MaxValue))
                return il.Ldc(decimal.ToInt64(value)).New(decimalType.GetConstructor(new[] { typeof(long) }));
        }
        var bits = decimal.GetBits(value);
        return il
            .Ldc(bits[0])
            .Ldc(bits[1])
            .Ldc(bits[2])
            .Ldc((bits[3] & 0x80000000L) > 0L)
            .Ldc((byte)(bits[3] >> 0x10))
            .New(decimalType.GetConstructor(new[] { typeof(int), typeof(int), typeof(int), typeof(bool), typeof(byte) }));
    }

    /// <summary>
    ///     Pushes a supplied value of type <see cref="DateTime"/> onto the evaluation stack.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="value">The value to push onto the evaluation stack</param>
    public static ILGenerator Ldc(this ILGenerator il, DateTime value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
#if NetCore
        var datetimeType = typeof(DateTime).GetTypeInfo();
#else
        var datetimeType = typeof(DateTime);
#endif
        return il.Ldc(value.Ticks).New(datetimeType.GetConstructor(new[] { typeof(long) }));
    }

    private static ILGenerator Ldc<T>(this ILGenerator il, T value)
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Boolean:
                return il.Ldc((bool)(object)value);
            case TypeCode.Char:
                return il.Ldc((char)(object)value);
            case TypeCode.Byte:
                return il.Ldc((byte)(object)value);
            case TypeCode.SByte:
                return il.Ldc((sbyte)(object)value);
            case TypeCode.Int16:
                return il.Ldc((short)(object)value);
            case TypeCode.UInt16:
                return il.Ldc((ushort)(object)value);
            case TypeCode.Int32:
                return il.Ldc((int)(object)value);
            case TypeCode.UInt32:
                return il.Ldc((uint)(object)value);
            case TypeCode.Int64:
                return il.Ldc((long)(object)value);
            case TypeCode.UInt64:
                return il.Ldc((ulong)(object)value);
            case TypeCode.Single:
                return il.Ldc((float)(object)value);
            case TypeCode.Double:
                return il.Ldc((double)(object)value);
            case TypeCode.String:
                return il.Ldc((string)(object)value);
            case TypeCode.Decimal:
                return il.Ldc((decimal)(object)value);
            case TypeCode.DateTime:
                return il.Ldc((DateTime)(object)value);
            default:
                throw new NotSupportedException();
        }
    }
}