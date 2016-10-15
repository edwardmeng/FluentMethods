using System;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the absolute value of a 8-bit signed integer.
    /// </summary>
    /// <param name="value">A number that is greater than , but less than or equal to .</param>
    /// <returns>A 8-bit signed integer.</returns>
    public static sbyte Abs(this sbyte value)
    {
        return Math.Abs(value);
    }
}