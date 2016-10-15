﻿public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="int" /> extension method that query if <paramref name="value"/> is even.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <returns><c>true</c> if even, <c>false</c> if not.</returns>
    public static bool IsEven(this int value)
    {
        return value % 2 == 0;
    }
}