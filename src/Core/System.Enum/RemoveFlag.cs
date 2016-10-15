using System;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    ///     Removes one or more bit fields from the current enumeration.
    /// </summary>
    /// <param name="this">The <see cref="Enum"/> to act on.</param>
    /// <param name="flag">An enumeration value to remove.</param>
    /// <returns>The enumeration value.</returns>
    public static TEnum RemoveFlag<TEnum>(this TEnum @this, TEnum flag)
        where TEnum : struct
    {
        return (TEnum)Enum.ToObject(typeof(TEnum), ((IConvertible)@this).ToInt32(CultureInfo.CurrentCulture) & ~((IConvertible)flag).ToInt32(CultureInfo.CurrentCulture));
    }
}