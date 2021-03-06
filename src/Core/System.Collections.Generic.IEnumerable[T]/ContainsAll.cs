﻿using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="IEnumerable{T}"/> extension method that query if <paramref name="collection"/> contains all.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <param name="comparer">An equality comparer to compare values.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="values"/> is null.</exception>
    public static bool ContainsAll<T>(this IEnumerable<T> collection, IEnumerable<T> values, IEqualityComparer<T> comparer)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (values == null)
        {
            throw new ArgumentNullException(nameof(values));
        }
        var array = collection.ToArray();
        return values.All(value => array.Contains(value, comparer));
    }

    /// <summary>
    ///     An <see cref="IEnumerable{T}"/> extension method that query if <paramref name="collection"/> contains all.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="values"/> is null.</exception>
    public static bool ContainsAll<T>(this IEnumerable<T> collection, IEnumerable<T> values)
    {
        return collection.ContainsAll(values, EqualityComparer<T>.Default);
    }

    /// <summary>
    ///     An <see cref="IEnumerable{T}"/> extension method that query if <paramref name="collection"/> contains all.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is null.</exception>
    public static bool ContainsAll<T>(this IEnumerable<T> collection, params T[] values)
    {
        return collection.ContainsAll((IEnumerable<T>) values);
    }
}