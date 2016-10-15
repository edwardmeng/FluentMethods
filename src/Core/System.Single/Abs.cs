using System;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the absolute value of a single-precision floating-point number.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to , but less than or equal to .</param>
    /// <returns>A single-precision floating-point number, x, such that 0 ? x ?.</returns>
    public static float Abs(this float value)
    {
        return Math.Abs(value);
    }
}