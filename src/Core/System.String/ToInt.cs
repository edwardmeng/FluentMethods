using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to an 32 bit integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static int ToInt(this string value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Converts a string to an 32 bit integer and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static int ToInt(this string value, int defaultValue)
    {
        try
        {
            return Convert.ToInt32(value);
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