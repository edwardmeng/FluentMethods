using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static DateTime ToDateTime(this string value)
    {
        return Convert.ToDateTime(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="DateTime"/> value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">
    /// The value to return if <paramref name="value"/> is an invalid value. 
    /// The default is the minimum time value on the system.
    /// </param>
    /// <returns>The converted value.</returns>
    public static DateTime ToDateTime(this string value, DateTime defaultValue)
    {
        try
        {
            return Convert.ToDateTime(value);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}