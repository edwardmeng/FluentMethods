using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that add value if the <paramref name="collection"/> doesn't contains it already.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is null.</exception>
    public static bool AddIfNotContains<T>(this ICollection<T> collection, T value)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (!collection.Contains(value))
        {
            collection.Add(value);
            return true;
        }

        return false;
    }
}