using System;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a string can be converted to the <see cref="DateTime"/> type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="DateTime"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsDateTime(this string value)
    {
        DateTime time;
        return DateTime.TryParse(value, out time);
    }
}