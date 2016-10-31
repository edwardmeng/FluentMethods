using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that removes if.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="value">The value.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="predicate"/> is null.</exception>
    public static bool RemoveIf<T>(this ICollection<T> collection, T value, Func<T, bool> predicate)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return predicate(value) && collection.Remove(value);
    }
}