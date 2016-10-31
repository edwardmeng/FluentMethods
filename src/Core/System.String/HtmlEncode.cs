using System.Web;

public static partial class Extensions
{
    /// <summary>
    ///     Converts a string to an HTML-encoded string.
    /// </summary>
    /// <param name="s">The string to encode.</param>
    /// <returns>An encoded string.</returns>
    public static string HtmlEncode(this string s)
    {
        return string.IsNullOrEmpty(s) ? s : HttpUtility.HtmlEncode(s);
    }
}