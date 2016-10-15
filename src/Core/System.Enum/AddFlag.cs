using System;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    ///     Adds one or more bit fields to the current enumeration.
    /// </summary>
    /// <param name="this">The <see cref="Enum"/> to act on.</param>
    /// <param name="flag">An enumeration value to add.</param>
    /// <returns>The enumeration value.</returns>
    public static TEnum AddFlag<TEnum>(this TEnum @this, TEnum flag)
        where TEnum : struct
    {
        return (TEnum)Enum.ToObject(typeof(TEnum), ((IConvertible)@this).ToInt32(CultureInfo.CurrentCulture) | ((IConvertible)flag).ToInt32(CultureInfo.CurrentCulture));
    }
}