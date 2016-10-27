using System;

public static partial class Extensions
{
    /// <summary>
    /// Converts a string to a <see cref="Guid"/> number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value.</returns>
    public static Guid ToGuid(this string value)
    {
        return new Guid(value);
    }

    /// <summary>
    /// Converts a string to a <see cref="Guid"/> value and specifies a default value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="defaultValue">The value to return if <paramref name="value"/> is <see langword="null"/> or is an invalid value.</param>
    /// <returns>The converted value.</returns>
    public static Guid ToGuid(this string value, Guid defaultValue)
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