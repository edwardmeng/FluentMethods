using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to an 64 bit integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static long ToInt64(this string value)
    {
        return Convert.ToInt64(value);
    }

    /// <summary>
    /// Converts a string to an 64 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static long ToInt64(this string value, long defaultValue)
    {
        try
        {
            return Convert.ToInt64(value);
        }
        catch (FormatException)
        {
            return defaultValue;
        }
        catch (OverflowException)
        {
            return defaultValue;
        }
    }
}