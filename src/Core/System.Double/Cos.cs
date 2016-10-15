using System;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the cosine of the specified angle.
    /// </summary>
    /// <param name="d">An angle, measured in radians.</param>
    /// <returns>The cosine of . If  is equal to , , or , this method returns .</returns>
    public static double Cos(this double d)
    {
        return Math.Cos(d);
    }
}