using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that adds a collection of objects to the end of collection collection only
    ///     for value who satisfies the predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/>, <paramref name="predicate"/> or <paramref name="values"/> is null.</exception>
    public static void AddRangeIf<T>(this ICollection<T> collection, Func<T, bool> predicate, IEnumerable<T> values)
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
                collection.Add(value);
            }
        }
    }

    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that adds a collection of objects to the end of collection collection only
    ///     for value who satisfies the predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="predicate"/> is null.</exception>
    public static void AddRangeIf<T>(this ICollection<T> collection, Func<T, bool> predicate, params T[] values)
    {
        collection.AddRangeIf(predicate,(IEnumerable<T>)values);
    }
}