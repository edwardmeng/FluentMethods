using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that removes value that satisfy the predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="predicate"/> is null.</exception>
    public static void RemoveAll<T>(this ICollection<T> collection, Func<T, bool> predicate)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        foreach (var item in collection.Where(predicate).ToArray())
        {
            collection.Remove(item);
        }
    }
}