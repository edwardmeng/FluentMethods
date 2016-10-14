using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Filters a sequence of values based on a predicate on when the <paramref name="condition"/> is <c>true</c>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="condition">A <see cref="Boolean"/> to determine whether the <paramref name="predicate"/> can be applied.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the predicate condition.</returns>
    /// <remarks>
    /// When building a LINQ query, you may need to involve optional filtering criteria. 
    /// Avoids if statements when building predicates &amp; lambdas for a query. 
    /// Useful when you don't know at compile time whether a filter should apply. 
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    [DebuggerStepThrough]
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, bool condition)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return condition ? source.Where(predicate) : source;
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate on when the <paramref name="condition"/> is <c>true</c>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
    /// <param name="predicate">
    /// A function to test each source element for a condition; 
    /// the second parameter of the function represents the index of the source element.
    /// </param>
    /// <param name="condition">
    /// A <see cref="Boolean"/> to determine whether the <paramref name="predicate"/> can be applied.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the predicate condition.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    [DebuggerStepThrough]
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate, bool condition)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return condition ? source.Where(predicate) : source;
    }
}