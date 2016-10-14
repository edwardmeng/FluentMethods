using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously determines whether all elements of a sequence satisfy a condition..
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether all element of <paramref name="source"/> satisfies the <paramref name="predicate"/>.
    /// <c>true</c> if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepperBoundary]
    public static async Task<bool> AllAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
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
        foreach (var local in source)
        {
            if (!await predicate(local, token))
            {
                return false;
            }
            token.ThrowIfCancellationRequested();
        }
        return true;
    }

    /// <summary>
    /// Asynchronously determines whether all elements of a sequence satisfy a condition..
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether all element of <paramref name="source"/> satisfies the <paramref name="predicate"/>.
    /// <c>true</c> if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepperBoundary]
    public static Task<bool> AllAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken token)
    {
        return source.AllAsync(async (x, t) => await predicate(x), token);
    }

    /// <summary>
    /// Asynchronously determines whether all elements of a sequence satisfy a condition..
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result whether all element of <paramref name="source"/> satisfies the <paramref name="predicate"/>.
    /// <c>true</c> if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    [DebuggerStepperBoundary]
    public static Task<bool> AllAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
    {
        return source.AllAsync(predicate, CancellationToken.None);
    }
}