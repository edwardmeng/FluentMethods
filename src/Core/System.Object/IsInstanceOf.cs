using System;

public static partial class Extensions
{
    /// <summary>
    ///     An object extension method that query if <paramref name="value"/> is instance of the specified type.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="value">The @value to act on.</param>
    /// <returns>true if instance of the specified type, false if not.</returns>
    public static bool IsInstanceOf<T>(this object value)
    {
        return value.IsInstanceOf(typeof(T));
    }

    /// <summary>
    ///     An object extension method that query if <paramref name="value"/> is instance of the specified type.
    /// </summary>
    /// <param name="value">The @value to act on.</param>
    /// <param name="targetType">Type of the target.</param>
    /// <returns>true if instance of the specified type, false if not.</returns>
    public static bool IsInstanceOf(this object value, Type targetType)
    {
        return targetType.IsInstanceOfType(value);
    }
}