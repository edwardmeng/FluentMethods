using System;

public static partial class Extensions
{
    /// <summary>
    /// Adds prefix to beginning of given string if it does not starts with the prefix.
    /// </summary>
    public static string EnsureStartsWith(this string value, string prefix)
    {
        return EnsureStartsWith(value, prefix, StringComparison.CurrentCulture);
    }

    /// <summary>
    /// Adds a prefix to beginning of given string if it does not starts with the prefix.
    /// </summary>
    public static string EnsureStartsWith(this string value, string prefix, StringComparison comparisonType)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.StartsWith(prefix, comparisonType))
        {
            return value;
        }

        return prefix + value;
    }

#if !NetCore
    
    /// <summary>
    /// Adds a prefix to beginning of given string if it does not starts with the prefix.
    /// </summary>
    public static string EnsureStartsWith(this string value, string prefix, bool ignoreCase, System.Globalization.CultureInfo culture)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.StartsWith(prefix, ignoreCase, culture))
        {
            return value;
        }

        return prefix + value;
    }
#endif
}