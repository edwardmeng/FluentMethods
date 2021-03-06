﻿public static partial class Extensions
{
#if !NetCore
    /// <summary>
    ///     Converts the value of a specified Unicode character to its lowercase equivalent using specified culture-
    ///     specific formatting information.
    /// </summary>
    /// <param name="c">The Unicode character to convert.</param>
    /// <param name="culture">An object that supplies culture-specific casing rules.</param>
    /// <returns>
    ///     The lowercase equivalent of , modified according to , or the unchanged value of , if  is already lowercase or
    ///     not alphabetic.
    /// </returns>
    public static char ToLower(this char c, System.Globalization.CultureInfo culture)
    {
        return char.ToLower(c, culture);
    }
#endif

    /// <summary>
    ///     Converts the value of a Unicode character to its lowercase equivalent.
    /// </summary>
    /// <param name="c">The Unicode character to convert.</param>
    /// <returns>
    ///     The lowercase equivalent of , or the unchanged value of , if  is already lowercase or not alphabetic.
    /// </returns>
    public static char ToLower(this char c)
    {
        return char.ToLower(c);
    }
}