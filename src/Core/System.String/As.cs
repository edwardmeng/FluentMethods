using System;
using System.ComponentModel;

public static partial class Extensions
{
    /// <summary>
    ///  Converts the string to an equivalent enumerated object, A parameter specifies whether the  operation is case-sensitive.
    /// </summary>
    /// <typeparam name="T">The Type of the enum</typeparam>
    /// <param name="name">To be converted  string</param>
    /// <param name="ignoreCase">True - ignore case; False - regard case. </param>
    /// <returns>An specify enumType value</returns>
    public static T AsEnum<T>(this string name, bool ignoreCase = false) where T : struct
    {
        if (name == null)
        {
            throw new ArgumentNullException("name");
        }
        return (T)Enum.Parse(typeof(T), name, ignoreCase);
    }

    /// <summary>
    /// Converts a string to the specified data type and specifies a default value.
    /// </summary>
    /// <typeparam name="TValue">The data type to convert to.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static TValue As<TValue>(this string value, TValue defaultValue = default(TValue))
    {
        try
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
            if (converter.CanConvertFrom(typeof(string)))
            {
                return (TValue)converter.ConvertFrom(value);
            }
            converter = TypeDescriptor.GetConverter(typeof(string));
            if (converter.CanConvertTo(typeof(TValue)))
            {
                return (TValue)converter.ConvertTo(value, typeof(TValue));
            }
        }
        catch
        {
        }
        return defaultValue;
    }

    /// <summary>
    /// Converts a string to a Boolean (true/false) value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static bool AsBool(this string value, bool defaultValue = false)
    {
        bool flag;
        if (!bool.TryParse(value, out flag))
        {
            return defaultValue;
        }
        return flag;
    }

    /// <summary>
    /// Converts a string to a <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static DateTime AsDateTime(this string value)
    {
        return value.AsDateTime(new DateTime());
    }

    /// <summary>
    /// Converts a string to a <see cref="DateTime"/> value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">
    /// The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value. 
    /// The default is the minimum time value on the system.
    /// </param>
    /// <returns>The converted value.</returns>
    public static DateTime AsDateTime(this string value, DateTime defaultValue)
    {
        DateTime time;
        if (!DateTime.TryParse(value, out time))
        {
            return defaultValue;
        }
        return time;
    }

    /// <summary>
    /// Converts a string to a <see cref="Decimal"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or invalid.</param>
    /// <returns>The converted value.</returns>
    public static decimal AsDecimal(this string value, decimal defaultValue = default(decimal))
    {
        return value.As(defaultValue);
    }

    /// <summary>
    /// Converts a string to a <see cref="Single"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static float AsFloat(this string value, float defaultValue = 0f)
    {
        float num;
        if (!float.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to an 32 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static short AsInt16(this string value, short defaultValue = 0)
    {
        short num;
        if (!short.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to an 32 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static int AsInt32(this string value, int defaultValue = 0)
    {
        int num;
        if (!int.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to an 64 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static long AsInt64(this string value, long defaultValue = 0)
    {
        long num;
        if (!long.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to a <see cref="Guid"/> number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static Guid AsGuid(this string value)
    {
        return value.AsGuid(Guid.Empty);
    }

    /// <summary>
    /// Converts a string to a <see cref="Guid"/> value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static Guid AsGuid(this string value, Guid defaultValue)
    {
        Guid guid;
        if (!Guid.TryParse(value, out guid))
        {
            return defaultValue;
        }
        return guid;
    }
}