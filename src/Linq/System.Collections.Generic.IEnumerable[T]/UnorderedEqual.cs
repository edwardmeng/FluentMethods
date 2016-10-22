using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether two collections are equal by unordered comparing their elements by using a specified <see cref="IEqualityComparer{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="ICollection{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="ICollection{T}"/> to compare to the first sequence.</param>
    /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to use to compare elements.</param>
    /// <returns>
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="comparer"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static bool UnorderedEqual<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
    {
        if (first == null)
        {
            throw new ArgumentNullException(nameof(first));
        }
        if (second == null)
        {
            throw new ArgumentNullException(nameof(second));
        }
        if (comparer == null) comparer = EqualityComparer<T>.Default;
        var list = first.ToList();
        foreach (var v in second)
        {
            var index = list.FindIndex(x => comparer.Equals(x, v));
            if (index == -1) return false;
            list.RemoveAt(index);
        }
        return list.Count == 0;
    }

    /// <summary>
    /// Determines whether two collections are equal by unordered comparing the elements by using the default equality comparer for their type.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="ICollection{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="ICollection{T}"/> to compare to the first sequence.</param>
    /// <returns>
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements are unordered equal according to the default equality comparer for their type; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/> or <paramref name="second"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static bool UnorderedEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        return first.UnorderedEqual(second, null);
    }

    /// <summary>
    /// Determines whether two collections are equal by unordered comparing their elements by using a specified <paramref name="predicate" /> function.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="ICollection{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="ICollection{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns>
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static bool UnorderedEqual<T>(this ICollection<T> first, ICollection<T> second, Func<T, T, bool> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return first.UnorderedEqual(second, new PredicateEqualityComparer<T>(predicate));
    }

    /// <summary>
    /// Determines whether two collections are equal by unordered comparing their elements by using a specified <paramref name="selector" /> function.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="first">An <see cref="ICollection{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="ICollection{T}"/> to compare to the first sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns>
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static bool UnorderedEqual<T, TKey>(this ICollection<T> first, ICollection<T> second, Func<T, TKey> selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }
        return first.UnorderedEqual(second, new SelectorEqualityComparer<T, TKey>(selector));
    }
}