using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the last element in the sequence that passes the test in the specified <paramref name="predicate"/> function,
    /// or default(TSource) if source is empty or if no element passes the test specified by <paramref name="predicate"/>.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    [DebuggerStepperBoundary]
    public static async Task<TSource> LastOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
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
        var result = default(TSource);
        foreach (var element in source)
        {
            if (await predicate(element, token))
            {
                result = element;
            }
            token.ThrowIfCancellationRequested();
        }
        return result;
    }

    /// <summary>
    /// Asynchronously returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the last element in the sequence that passes the test in the specified <paramref name="predicate"/> function,
    /// or default(TSource) if source is empty or if no element passes the test specified by <paramref name="predicate"/>.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    [DebuggerStepperBoundary]
    public static Task<TSource> LastOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken token)
    {
        return source.LastOrDefaultAsync(async (x, t) => await predicate(x), token);
    }

    /// <summary>
    /// Asynchronously returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the last element in the sequence that passes the test in the specified <paramref name="predicate"/> function,
    /// or default(TSource) if source is empty or if no element passes the test specified by <paramref name="predicate"/>.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    [DebuggerStepperBoundary]
    public static Task<TSource> LastOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
    {
        return source.LastOrDefaultAsync(predicate, CancellationToken.None);
    }
}