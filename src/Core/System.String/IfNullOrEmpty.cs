using System;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that if null or empty.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>A string.</returns>
    public static string IfNullOrEmpty(this string value, string defaultValue = null)
    {
        return value.IfNullOrEmpty(() => defaultValue);
    }

    /// <summary>
    ///     A string extension method that if null or empty.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <returns>A string.</returns>
    public static string IfNullOrEmpty(this string value, Func<string> defaultValueFactory)
    {
        return value.IsNotNullOrEmpty() ? value : defaultValueFactory();
    }
}