using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously determines whether two collections are equal by unordered comparing their elements by using a specified <see cref="IEqualityComparer{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static async Task<bool> UnorderedEqualAsync<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
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
        var list = first.ToList();
        foreach (var v in second)
        {
            var index = -1;
            for (var i = 0; i < list.Count; i++)
            {
                if (await predicate(v, list[i], token))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return false;
            list.RemoveAt(index);
        }
        return list.Count == 0;
    }

    /// <summary>
    /// Asynchronously determines whether two collections are equal by unordered comparing their elements by using a specified <see cref="IEqualityComparer{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> UnorderedEqualAsync<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, Task<bool>> predicate, CancellationToken token)
    {
        return first.UnorderedEqualAsync(second, async (x, y, t) => await predicate(x, y), token);
    }

    /// <summary>
    /// Asynchronously determines whether two collections are equal by unordered comparing their elements by using a specified <see cref="IEqualityComparer{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> UnorderedEqualAsync<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, Task<bool>> predicate)
    {
        return first.UnorderedEqualAsync(second, predicate, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously determines whether two collections are equal by unordered comparing their elements by using a specified <paramref name="selector" /> function.
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
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    //[DebuggerStepThrough]
    public static async Task<bool> UnorderedEqualAsync<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, CancellationToken, Task<TKey>> selector, CancellationToken token)
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
        var list = first.ToList();
        var keys = new List<TKey>();
        foreach (var v in second)
        {
            var index = -1;
            var key = await selector(v, token);
            for (var i = 0; i < list.Count; i++)
            {
                while (keys.Count <= i)
                {
                    keys.Add(await selector(list[keys.Count], token));
                }
                if (EqualityComparer<TKey>.Default.Equals(key, keys[i]))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return false;
            list.RemoveAt(index);
            keys.RemoveAt(index);
        }
        return list.Count == 0;
    }

    /// <summary>
    /// Asynchronously determines whether two collections are equal by unordered comparing their elements by using a specified <paramref name="selector" /> function.
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
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    //[DebuggerStepThrough]
    public static Task<bool> UnorderedEqualAsync<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, Task<TKey>> selector, CancellationToken token)
    {
        return first.UnorderedEqualAsync(second, async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously determines whether two collections are equal by unordered comparing their elements by using a specified <paramref name="selector" /> function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether two sequences are equal by comparing their elements.
    /// <c>true</c> if the two source collections are of equal length and their corresponding elements compare unordered equal according to comparer; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="first"/>, <paramref name="second"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepThrough]
    public static Task<bool> UnorderedEqualAsync<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, Task<TKey>> selector)
    {
        return first.UnorderedEqualAsync(second, selector, CancellationToken.None);
    }
}