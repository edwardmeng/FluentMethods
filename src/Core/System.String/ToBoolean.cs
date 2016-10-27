using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a <see cref="bool"/> (true/false) value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static bool ToBoolean(this string value)
    {
        return Convert.ToBoolean(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="bool"/> (true/false) value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static bool ToBoolean(this string value, bool defaultValue)
    {
        try
        {
            return Convert.ToBoolean(value);
        }
        catch (FormatException)
        {
            return defaultValue;
        }
    }
}