using System;
using System.ComponentModel;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a string can be converted to the specified data type.
    /// </summary>
    /// <typeparam name="TValue">The data type to convert to.</typeparam>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to the specified type; otherwise, <c>false</c>.</returns>
    public static bool Is<TValue>(this string value)
    {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
        try
        {
            if ((value == null) || converter.CanConvertFrom(null, value.GetType()))
            {
                converter.ConvertFrom(null, CultureInfo.CurrentCulture, value);
                return true;
            }
        }
        catch
        {
        }
        return false;
    }

    /// <summary>
    /// Determines whether a string can be converted to the Boolean (true/false) type.
    /// </summary>
    /// <param name="value">The string value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="Boolean"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsBool(this string value)
    {
        bool flag;
        return bool.TryParse(value, out flag);
    }

    /// <summary>
    /// Determines whether a string can be converted to the <see cref="DateTime"/> type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="DateTime"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsDateTime(this string value)
    {
        DateTime time;
        return DateTime.TryParse(value, out time);
    }

    /// <summary>
    /// Determines whether a string can be converted to the <see cref="Decimal"/> type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="Decimal"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsDecimal(this string value)
    {
        return value.Is<decimal>();
    }

    /// <summary>
    /// Determines whether a string can be converted to the <see cref="Single"/> type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="Single"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsFloat(this string value)
    {
        float num;
        return float.TryParse(value, out num);
    }

    /// <summary>
    /// Determines whether a string can be converted to an 16 bit integer.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to an integer; otherwise, <c>false</c>.</returns>
    public static bool IsInt16(this string value)
    {
        short num;
        return short.TryParse(value, out num);
    }

    /// <summary>
    /// Determines whether a string can be converted to an 32 bit integer.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to an integer; otherwise, <c>false</c>.</returns>
    public static bool IsInt32(this string value)
    {
        int num;
        return int.TryParse(value, out num);
    }

    /// <summary>
    /// Determines whether a string can be converted to an 64 bit integer.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to an integer; otherwise, <c>false</c>.</returns>
    public static bool IsInt64(this string value)
    {
        long num;
        return long.TryParse(value, out num);
    }

    /// <summary>
    /// Determines whether a string can be converted to the <see cref="Guid"/> type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="Guid"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsGuid(this string value)
    {
        Guid guid;
        return Guid.TryParse(value, out guid);
    }

}