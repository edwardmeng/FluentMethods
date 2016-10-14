using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Produces the set union of two sequences by using the specified key selector function for the equality comparison.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key member of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union.</param>
    /// <param name="selector">The key selector function to select the comparison key.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null"/>.
    /// </exception>
    [DebuggerStepThrough]
    public static IEnumerable<TSource> Union<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> selector)
    {
        if (first == null)
        {
            throw new ArgumentNullException(nameof(first));
        }
        if (second == null)
        {
            throw new ArgumentNullException(nameof(second));
        }
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }
        return first.Union(second, new SelectorEqualityComparer<TSource, TKey>(selector));
    }

    /// <summary>
    /// Produces the set union of two sequences by using the specified equality predicate function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union.</param>
    /// <param name="predicate">The equality predicate function to compare values.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    [DebuggerStepThrough]
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> predicate)
    {
        if (first == null)
        {
            throw new ArgumentNullException(nameof(first));
        }
        if (second == null)
        {
            throw new ArgumentNullException(nameof(second));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return first.Union(second, new PredicateEqualityComparer<TSource>(predicate));
    }
}