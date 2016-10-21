using System;

public static partial class Extensions
{
    /// <summary>
    /// Adds a suffix to end of given string if it does not ends with the suffix.
    /// </summary>
    public static string EnsureEndsWith(this string value, string suffix)
    {
        return EnsureEndsWith(value, suffix, StringComparison.CurrentCulture);
    }

    /// <summary>
    /// Adds a suffix to end of given string if it does not ends with the suffix.
    /// </summary>
    public static string EnsureEndsWith(this string value, string suffix, StringComparison comparisonType)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.EndsWith(suffix, comparisonType))
        {
            return value;
        }

        return value + suffix;
    }

#if !NetCore
    
    /// <summary>
    /// Adds a suffix to end of given string if it does not ends with the suffix.
    /// </summary>
    public static string EnsureEndsWith(this string value, string suffix, bool ignoreCase, System.Globalization.CultureInfo culture)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.EndsWith(suffix, ignoreCase, culture))
        {
            return value;
        }

        return value + suffix;
    }
#endif
}