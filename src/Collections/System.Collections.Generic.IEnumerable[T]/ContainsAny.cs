using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    ///     An <see cref="IEnumerable{T}"/> extension method that query if <paramref name="collection"/> contains any.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    public static bool ContainsAny<T>(this IEnumerable<T> collection, IEnumerable<T> values)
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
        return values.Any(value => array.Contains(value));
    }

    /// <summary>
    ///     An <see cref="IEnumerable{T}"/> extension method that query if <paramref name="collection"/> contains any.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
    public static bool ContainsAny<T>(this IEnumerable<T> collection, params T[] values)
    {
        return collection.ContainsAny((IEnumerable<T>)values);
    }
}