using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that removes range item that satisfy the predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    public static void RemoveRangeIf<T>(this ICollection<T> collection, Func<T, bool> predicate, IEnumerable<T> values)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        if (values == null)
        {
            throw new ArgumentNullException(nameof(values));
        }
        foreach (var value in values)
        {
            if (predicate(value))
            {
                collection.Remove(value);
            }
        }
    }

    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that removes range item that satisfy the predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    public static void RemoveRangeIf<T>(this ICollection<T> collection, Func<T, bool> predicate, params T[] values)
    {
        collection.RemoveRangeIf(predicate, (IEnumerable<T>)values);
    }
}