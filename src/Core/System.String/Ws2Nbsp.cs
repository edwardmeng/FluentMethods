public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that newline 2 line break.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>A string.</returns>
    public static string Ws2Nbsp(this string @this)
    {
        return @this.IsNullOrEmpty() ? @this : @this.Replace(" ", "&nbsp;").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
    }
}