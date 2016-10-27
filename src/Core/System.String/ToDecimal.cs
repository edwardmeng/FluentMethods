using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a <see cref="decimal"/> number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static decimal ToDecimal(this string value)
    {
        return Convert.ToDecimal(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="decimal"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is invalid.</param>
    /// <returns>The converted value.</returns>
    public static decimal ToDecimal(this string value, decimal defaultValue)
    {
        try
        {
            return Convert.ToDecimal(value);
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