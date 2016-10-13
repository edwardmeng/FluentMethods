using System.Text;
using System.Web;

public static partial class Extensions
{

    /// <summary>
    ///     Converts a string that has been encoded for transmission in a URL into a decoded string.
    /// </summary>
    /// <param name="str">The string to decode.</param>
    /// <returns>A decoded string.</returns>
    public static string UrlDecode(this string str)
    {
        return string.IsNullOrEmpty(str) ? str : HttpUtility.UrlDecode(str);
    }

    /// <summary>
    ///     Converts a URL-encoded string into a decoded string, using the specified encoding object.
    /// </summary>
    /// <param name="str">The string to decode.</param>
    /// <param name="e">The  that specifies the decoding scheme.</param>
    /// <returns>A decoded string.</returns>
    public static string UrlDecode(this string str, Encoding e)
    {
        return string.IsNullOrEmpty(str) ? str : HttpUtility.UrlDecode(str, e);
    }
}