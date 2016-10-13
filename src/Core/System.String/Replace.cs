using System;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.
    /// A parameter specifies the type of search to use for the specified string.
    /// </summary>
    /// <param name="originalString">The original string to be replaced.</param>
    /// <param name="oldValue">The string to be replaced.</param>
    /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>. </param>
    /// <param name="comparison">One of the enumeration values that specifies the rules for the search. </param>
    /// <returns>A string that is equivalent to the current string except that all instances of <paramref name="oldValue"/> are replaced with <paramref name="newValue"/>.</returns>
    public static string Replace(this string originalString, string oldValue, string newValue, StringComparison comparison = StringComparison.CurrentCulture)
    {
        if (originalString.IsNullOrEmpty()) return originalString;
        var sb = new StringBuilder();

        int previousIndex = 0;
        int index = originalString.IndexOf(oldValue, comparison);
        while (index != -1)
        {
            sb.Append(originalString.Substring(previousIndex, index - previousIndex));
            sb.Append(newValue);
            index += oldValue.Length;

            previousIndex = index;
            index = originalString.IndexOf(oldValue, index, comparison);
        }
        sb.Append(originalString.Substring(previousIndex));

        return sb.ToString();
    }
}