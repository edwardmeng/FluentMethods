public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that query if '@this' is not null or white space.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>true if empty, false if not.</returns>
    public static bool IsNotNullOrWhiteSpace(this string @this)
    {
        return !string.IsNullOrWhiteSpace(@this);
    }
}