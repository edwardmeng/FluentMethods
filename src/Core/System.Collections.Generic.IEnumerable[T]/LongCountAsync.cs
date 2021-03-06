﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously returns an <see cref="Int64"/> that represents how many elements in a sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the number that represents how many elements in the sequence satisfy the condition in the predicate function.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="OverflowException">The number of elements in source is larger than <see cref="Int64.MaxValue"/>.</exception>
    [DebuggerStepThrough]
    public static async Task<long> LongCountAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
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
        long count = 0;
        foreach (var element in source)
        {
            checked
            {
                if (await predicate(element, token)) count++;
                token.ThrowIfCancellationRequested();
            }
        }
        return count;
    }

    /// <summary>
    /// Asynchronously returns an <see cref="Int64"/> that represents how many elements in a sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the number that represents how many elements in the sequence satisfy the condition in the predicate function.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="OverflowException">The number of elements in source is larger than <see cref="Int64.MaxValue"/>.</exception>
    [DebuggerStepThrough]
    public static Task<long> LongCountAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken token)
    {
        return source.LongCountAsync(async (x, t) => await predicate(x), token);
    }

    /// <summary>
    /// Asynchronously returns an <see cref="Int64"/> that represents how many elements in a sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">A sequence that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the number that represents how many elements in the sequence satisfy the condition in the predicate function.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="OverflowException">The number of elements in source is larger than <see cref="Int64.MaxValue"/>.</exception>
    [DebuggerStepThrough]
    public static Task<long> LongCountAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
    {
        return source.LongCountAsync(predicate, CancellationToken.None);
    }
}