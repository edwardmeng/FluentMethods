using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a <see cref="double"/> number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static double ToDouble(this string value)
    {
        return Convert.ToDouble(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="double"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static double ToDouble(this string value, double defaultValue)
    {
        try
        {
            return Convert.ToDouble(value);
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