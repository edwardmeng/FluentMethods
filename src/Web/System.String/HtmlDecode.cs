using System.Web;

public static partial class Extensions
{
    /// <summary>
    ///     Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.
    /// </summary>
    /// <param name="s">The string to decode.</param>
    /// <returns>A decoded string.</returns>
    public static string HtmlDecode(this string s)
    {
        return string.IsNullOrEmpty(s) ? s : HttpUtility.HtmlDecode(s);
    }
}