public static partial class Extensions
{
    /// <summary>
    ///     Indicates whether the specified Unicode character is categorized as white space.
    /// </summary>
    /// <param name="c">The Unicode character to evaluate.</param>
    /// <returns>true if  is white space; otherwise, false.</returns>
    public static bool IsWhiteSpace(this char c)
    {
        return char.IsWhiteSpace(c);
    }
}