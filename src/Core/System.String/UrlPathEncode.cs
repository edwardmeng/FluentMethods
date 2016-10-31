using System.Web;

public static partial class Extensions
{
    /// <summary>
    ///     Encodes the path portion of a URL string for reliable HTTP transmission from the Web server to a client.
    /// </summary>
    /// <param name="str">The text to encode.</param>
    /// <returns>The encoded text.</returns>
    public static string UrlPathEncode(this string str)
    {
        return string.IsNullOrEmpty(str) ? str : HttpUtility.UrlPathEncode(str);
    }
}