using System.Web;

public static partial class Extensions
{
    /// <summary>
    ///     Minimally converts a string to an HTML-encoded string.
    /// </summary>
    /// <param name="s">The string to encode.</param>
    /// <returns>An encoded string.</returns>
    public static string HtmlAttributeEncode(this string s)
    {
        return string.IsNullOrEmpty(s) ? s : HttpUtility.HtmlAttributeEncode(s);
    }
}