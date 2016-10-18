public static partial class Extensions
{
    /// <summary>
    ///     A T extension method that query if '@value' is not null.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="value">The value to act on.</param>
    /// <returns>true if not null, false if not.</returns>
    public static bool IsNotNull<T>(this T value) where T : class
    {
        return value != null;
    }
}