using System;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a string can be converted to a number type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to number type; otherwise, <c>false</c>.</returns>
    public static bool IsNumber(this string value)
    {
        double num;
        return double.TryParse(value, NumberStyles.Number | NumberStyles.Float, NumberFormatInfo.CurrentInfo, out num);
    }
}