using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a <see cref="float"/> number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static float ToFloat(this string value)
    {
        return Convert.ToSingle(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="float"/> number and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static float ToFloat(this string value, float defaultValue)
    {
        try
        {
            return Convert.ToSingle(value);
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