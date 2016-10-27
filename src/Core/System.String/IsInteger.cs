using System;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a string can be converted to an integer.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to an integer; otherwise, <c>false</c>.</returns>
    public static bool IsInteger(this string value)
    {
        long num;
        return long.TryParse(value, NumberStyles.AllowThousands | NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out num);
    }
}