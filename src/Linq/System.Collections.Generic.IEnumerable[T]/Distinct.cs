using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Returns distinct elements from a sequence by using the <paramref name="predicate" /> function to determine if two elements are the same.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        return source.Distinct(new PredicateEqualityComparer<TSource>(predicate));
    }

    /// <summary>
    /// Returns distinct elements from a sequence by using the <paramref name="selector" /> function to select the comparison key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns>
    /// An <see cref="IEnumerable&lt;T&gt;"/> that contains distinct elements from the source sequence.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return source.Distinct(new SelectorEqualityComparer<TSource, TKey>(selector));
    }
}