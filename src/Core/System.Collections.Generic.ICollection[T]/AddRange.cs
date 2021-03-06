﻿using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that adds a range to 'values'.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="values"/> is null.</exception>
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (values == null)
        {
            throw new ArgumentNullException(nameof(values));
        }
        foreach (var value in values)
        {
            collection.Add(value);
        }
    }

    /// <summary>
    ///     An <see cref="ICollection{T}"/> extension method that adds a range to 'values'.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is null.</exception>
    public static void AddRange<T>(this ICollection<T> collection, params T[] values)
    {
        collection.AddRange((IEnumerable<T>)values);
    }
}