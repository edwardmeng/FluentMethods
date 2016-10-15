public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="int" /> extension method that query if <paramref name="value"/> is odd.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <returns><c>true</c> if odd, <c>false</c> if not.</returns>
    public static bool IsOdd(this int value)
    {
        return value % 2 != 0;
    }
}