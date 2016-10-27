using System;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a string can be converted to the <see cref="Guid"/> type.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><c>true</c> if <paramref name="value"/> can be converted to <see cref="Guid"/> type; otherwise, <c>false</c>.</returns>
    public static bool IsGuid(this string value)
    {
#if Net35
        try
        {
            var guid = new Guid(value);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
#else
        Guid guid;
        return Guid.TryParse(value, out guid);
#endif
    }
}