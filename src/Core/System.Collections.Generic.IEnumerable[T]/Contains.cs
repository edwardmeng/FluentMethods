using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a sequence contains a specified element by using the <paramref name="predicate" /> function to determine if two elements are the same.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns><c>true</c> if the source sequence contains an element that has the specified value; otherwise, <c>false</c>.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        return source.Contains(value, new PredicateEqualityComparer<TSource>(predicate));
    }

    /// <summary>
    /// Determines whether a sequence contains a specified element by using the <paramref name="selector" /> function to select the comparison key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns><c>true</c> if the source sequence contains an element that has the specified value; otherwise, <c>false</c>.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static bool Contains<TSource, TKey>(this IEnumerable<TSource> source, TSource value, Func<TSource, TKey> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return source.Contains(value, new SelectorEqualityComparer<TSource, TKey>(selector));
    }
}