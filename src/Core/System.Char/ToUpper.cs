public static partial class Extensions
{
#if !NetCore
    /// <summary>
    ///     Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-
    ///     specific formatting information.
    /// </summary>
    /// <param name="c">The Unicode character to convert.</param>
    /// <param name="culture">An object that supplies culture-specific casing rules.</param>
    /// <returns>
    ///     The uppercase equivalent of , modified according to , or the unchanged value of  if  is already uppercase,
    ///     has no uppercase equivalent, or is not alphabetic.
    /// </returns>
    public static char ToUpper(this char c, System.Globalization.CultureInfo culture)
    {
        return char.ToUpper(c, culture);
    }
#endif

    /// <summary>
    ///     Converts the value of a Unicode character to its uppercase equivalent.
    /// </summary>
    /// <param name="c">The Unicode character to convert.</param>
    /// <returns>
    ///     The uppercase equivalent of , or the unchanged value of  if  is already uppercase, has no uppercase
    ///     equivalent, or is not alphabetic.
    /// </returns>
    public static char ToUpper(this char c)
    {
        return char.ToUpper(c);
    }
}