using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a Boolean (true/false) value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static bool AsBool(this string value)
    {
        return bool.Parse(value);
    }

    /// <summary>
    /// Converts a string to a Boolean (true/false) value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static bool AsBool(this string value, bool defaultValue)
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
        return DateTime.Parse(value);
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
    /// <returns>The converted value.</returns>
    public static decimal AsDecimal(this string value)
    {
        return decimal.Parse(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="Decimal"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or invalid.</param>
    /// <returns>The converted value.</returns>
    public static decimal AsDecimal(this string value, decimal defaultValue)
    {
        decimal num;
        if (!decimal.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to a <see cref="Single"/> number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static float AsFloat(this string value)
    {
        return float.Parse(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="Single"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static float AsFloat(this string value, float defaultValue)
    {
        float num;
        if (!float.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to an 32 bit integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static short AsInt16(this string value)
    {
        return short.Parse(value);
    }

    /// <summary>
    /// Converts a string to an 32 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static short AsInt16(this string value, short defaultValue)
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
    /// <returns>The converted value.</returns>
    public static int AsInt32(this string value)
    {
        return int.Parse(value);
    }

    /// <summary>
    /// Converts a string to an 32 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static int AsInt32(this string value, int defaultValue)
    {
        int num;
        if (!int.TryParse(value, out num))
        {
            return defaultValue;
        }
        return num;
    }

    /// <summary>
    /// Converts a string to an 64 bit integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static long AsInt64(this string value)
    {
        return long.Parse(value);
    }

    /// <summary>
    /// Converts a string to an 64 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static long AsInt64(this string value, long defaultValue)
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
        return new Guid(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="Guid"/> value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static Guid AsGuid(this string value, Guid defaultValue)
    {
#if Net35
        try
        {
            return new Guid(value);
        }
        catch
        {
            return defaultValue;
        }
#else
        Guid guid;
        if (!Guid.TryParse(value, out guid))
        {
            return defaultValue;
        }
        return guid;
#endif
    }
}