public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that unescape XML.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>A string.</returns>
    public static string XmlDecode(this string @this)
    {
        return @this.IsNullOrEmpty() ? @this : @this.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "'");
    }
}