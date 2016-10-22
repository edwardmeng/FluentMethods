using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously determines whether two sequences are equal by comparing their elements by using a specified <paramref name="predicate" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static async Task<bool> SequenceEqualAsync<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
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
        using (var e1 = first.GetEnumerator())
        using (var e2 = second.GetEnumerator())
        {
            while (e1.MoveNext())
            {
                if (!(e2.MoveNext() && await predicate(e1.Current, e2.Current, token))) return false;
                token.ThrowIfCancellationRequested();
            }
            if (e2.MoveNext()) return false;
        }
        return true;
    }

    /// <summary>
    /// Asynchronously determines whether two sequences are equal by comparing their elements by using a specified <paramref name="predicate" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> SequenceEqualAsync<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, Task<bool>> predicate, CancellationToken token)
    {
        return first.SequenceEqualAsync(second, async (x, y, t) => await predicate(x, y), token);
    }

    /// <summary>
    /// Asynchronously determines whether two sequences are equal by comparing their elements by using a specified <paramref name="predicate" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> SequenceEqualAsync<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, Task<bool>> predicate)
    {
        return first.SequenceEqualAsync(second, predicate, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously determines whether two sequences are equal by comparing their elements by using a specified <paramref name="selector" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static async Task<bool> SequenceEqualAsync<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, CancellationToken, Task<TKey>> selector, CancellationToken token)
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
        using (var e1 = first.GetEnumerator())
        using (var e2 = second.GetEnumerator())
        {
            while (e1.MoveNext())
            {
                if (!(e2.MoveNext() && EqualityComparer<TKey>.Default.Equals(await selector(e1.Current, token), await selector(e2.Current, token)))) return false;
                token.ThrowIfCancellationRequested();
            }
            if (e2.MoveNext()) return false;
        }
        return true;
    }

    /// <summary>
    /// Asynchronously determines whether two sequences are equal by comparing their elements by using a specified <paramref name="selector" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> SequenceEqualAsync<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, Task<TKey>> selector, CancellationToken token)
    {
        return first.SequenceEqualAsync(second, async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously determines whether two sequences are equal by comparing their elements by using a specified <paramref name="selector" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> SequenceEqualAsync<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, Task<TKey>> selector)
    {
        return first.SequenceEqualAsync(second, selector, CancellationToken.None);
    }
}