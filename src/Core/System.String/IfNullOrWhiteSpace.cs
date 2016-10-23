using System;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that if null or white space.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>A string.</returns>
    public static string IfNullOrWhiteSpace(this string value, string defaultValue = null)
    {
        return value.IfNullOrWhiteSpace(() => defaultValue);
    }

    /// <summary>
    ///     A string extension method that if null or white space.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <returns>A string.</returns>
    public static string IfNullOrWhiteSpace(this string value, Func<string> defaultValueFactory)
    {
        return value.IsNotNullOrWhiteSpace() ? value : defaultValueFactory();
    }
}