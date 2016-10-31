using System.Web;

public static partial class Extensions
{
    /// <summary>
    ///     Encodes a string.
    /// </summary>
    /// <param name="value">A string to encode.</param>
    /// <param name="addDoubleQuotes">
    ///     A value that indicates whether double quotation marks will be included around the
    ///     encoded string.
    /// </param>
    /// <returns>An encoded string.</returns>
    public static string JavaScriptStringEncode(this string value, bool addDoubleQuotes = false)
    {
        return HttpUtility.JavaScriptStringEncode(value, addDoubleQuotes);
    }
}