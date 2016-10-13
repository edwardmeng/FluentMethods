public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that newline 2 line break.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>A string.</returns>
    public static string Nbsp2Ws(this string @this)
    {
        return @this.IsNullOrEmpty() ? @this : @this.Replace("&nbsp;&nbsp;&nbsp;&nbsp;", "\t", System.StringComparison.CurrentCultureIgnoreCase).Replace("&nbsp;", " ", System.StringComparison.CurrentCultureIgnoreCase);
    }
}