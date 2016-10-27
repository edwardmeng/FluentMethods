using System.Text.RegularExpressions;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that newline 2 line break.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <returns>A string.</returns>
    public static string Nbsp2Ws(this string value)
    {
        if (value.IsNullOrEmpty()) return value;
        value = Regex.Replace(value, @"(\&nbsp\;|\&\#160\;){4}", "\t",RegexOptions.IgnoreCase);
        value = value.Replace("&nbsp;", " ", System.StringComparison.CurrentCultureIgnoreCase);
        value = value.Replace("&#160;", " ", System.StringComparison.CurrentCultureIgnoreCase);
        return value;
    }
}