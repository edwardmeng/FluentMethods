using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether two sequences are equal by comparing their elements by using a specified <paramref name="predicate" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns><c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> predicate)
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
        return first.SequenceEqual(second, new PredicateEqualityComparer<TSource>(predicate));
    }

    /// <summary>
    /// Determines whether two sequences are equal by comparing their elements by using a specified <paramref name="selector" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns><c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static bool SequenceEqual<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> selector)
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
        return first.SequenceEqual(second, new SelectorEqualityComparer<TSource, TKey>(selector));
    }
}