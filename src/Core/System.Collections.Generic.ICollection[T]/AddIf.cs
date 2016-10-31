using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that adds only if the value satisfies the predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="predicate"/> is null.</exception>
    public static bool AddIf<T>(this ICollection<T> collection, Func<T, bool> predicate, T value)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        if (predicate(value))
        {
            collection.Add(value);
            return true;
        }

        return false;
    }
}