public static partial class Extensions
{
    /// <summary>
    /// Determines whether a string can be converted to the <see cref="bool"/> (true/false) type.
    /// </summary>
    /// <param name="value">The string value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="bool"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsBoolean(this string value)
    {
        bool flag;
        return bool.TryParse(value, out flag);
    }
}