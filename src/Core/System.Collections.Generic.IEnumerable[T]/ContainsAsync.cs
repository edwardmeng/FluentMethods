using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously determines whether a sequence contains a specified element by using the <paramref name="predicate" /> function to determine if two elements are the same.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the value indicating whether the source sequence contains an element that has the specified value.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<bool> ContainsAsync<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        foreach (var element in source)
        {
            if (await predicate(element, value, token)) return true;
            token.ThrowIfCancellationRequested();
        }
        return false;
    }
    /// <summary>
    /// Asynchronously determines whether a sequence contains a specified element by using the <paramref name="predicate" /> function to determine if two elements are the same.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the value indicating whether the source sequence contains an element that has the specified value.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<bool> ContainsAsync<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, Task<bool>> predicate, CancellationToken token)
    {
        return source.ContainsAsync(value, async (x, y, t) => await predicate(x, y), token);
    }

    /// <summary>
    /// Asynchronously determines whether a sequence contains a specified element by using the <paramref name="predicate" /> function to determine if two elements are the same.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="predicate">A predicate function to determine if two elements are the same.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the value indicating whether the source sequence contains an element that has the specified value.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<bool> ContainsAsync<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, Task<bool>> predicate)
    {
        return source.ContainsAsync(value, predicate, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously determines whether a sequence contains a specified element by using the <paramref name="selector" /> function to select the comparison key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the value indicating whether the source sequence contains an element that has the specified value.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<bool> ContainsAsync<TSource, TKey>(this IEnumerable<TSource> source, TSource value, Func<TSource, CancellationToken, Task<TKey>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }
        foreach (var element in source)
        {
            if (EqualityComparer<TKey>.Default.Equals(await selector(element, token), await selector(value, token))) return true;
            token.ThrowIfCancellationRequested();
        }
        return false;
    }

    /// <summary>
    /// Asynchronously determines whether a sequence contains a specified element by using the <paramref name="selector" /> function to select the comparison key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the value indicating whether the source sequence contains an element that has the specified value.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<bool> ContainsAsync<TSource, TKey>(this IEnumerable<TSource> source, TSource value, Func<TSource, Task<TKey>> selector, CancellationToken token)
    {
        return source.ContainsAsync(value, async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously determines whether a sequence contains a specified element by using the <paramref name="selector" /> function to select the comparison key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <param name="source">A sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="selector">The selector function to select the comparison key.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the value indicating whether the source sequence contains an element that has the specified value.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<bool> ContainsAsync<TSource, TKey>(this IEnumerable<TSource> source, TSource value, Func<TSource, Task<TKey>> selector)
    {
        return source.ContainsAsync(value, selector, CancellationToken.None);
    }
}