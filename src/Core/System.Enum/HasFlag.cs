using System;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    ///     Determines whether one or more bit fields are set in the current instance.
    /// </summary>
    /// <param name="this">The <see cref="Enum"/> to act on.</param>
    /// <param name="flag">An enumeration value.</param>
    /// <returns><c>true</c> if the bit field or bit fields that are set in flag are also set in the current instance; otherwise, <c>false</c>.</returns>
    public static bool HasFlag<TEnum>(this TEnum @this, TEnum flag)
        where TEnum : struct
    {
        var flagValue = ((IConvertible)flag).ToInt32(CultureInfo.CurrentCulture);
        return (((IConvertible)@this).ToInt32(CultureInfo.CurrentCulture) & flagValue) == flagValue;
    }
}