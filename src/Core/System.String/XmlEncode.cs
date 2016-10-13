public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that escape XML.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>A string.</returns>
    public static string XmlEncode(this string @this)
    {
        return @this.IsNullOrEmpty() ? @this : @this.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
    }
}