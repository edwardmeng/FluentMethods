﻿public static partial class Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the specified number evaluates to negative or positive infinity.
    /// </summary>
    /// <param name="value">A single-precision floating-point number.</param>
    /// <returns>true if  evaluates to  or ; otherwise, false.</returns>
    public static bool IsInfinity(this float value)
    {
        return float.IsInfinity(value);
    }
}