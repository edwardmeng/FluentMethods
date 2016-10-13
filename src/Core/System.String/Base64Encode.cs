using System;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that encode the string to Base64.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The encoded string to Base64.</returns>
    public static string Base64Encode(this string @this)
    {
        return @this.IsNullOrEmpty() ? @this : Convert.ToBase64String(Encoding.UTF8.GetBytes(@this));
    }
}