﻿public static partial class Extensions
{
    /// <summary>
    ///     Indicates whether the specified Unicode character is categorized as a symbol character.
    /// </summary>
    /// <param name="c">The Unicode character to evaluate.</param>
    /// <returns>true if  is a symbol character; otherwise, false.</returns>
    public static bool IsSymbol(this char c)
    {
        return char.IsSymbol(c);
    }
}