﻿using System;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the tangent of the specified angle.
    /// </summary>
    /// <param name="a">An angle, measured in radians.</param>
    /// <returns>The tangent of . If  is equal to , , or , this method returns .</returns>
    public static double Tan(this double a)
    {
        return Math.Tan(a);
    }
}