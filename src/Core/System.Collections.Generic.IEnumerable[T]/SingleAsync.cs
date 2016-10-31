using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the single element of the input sequence that satisfies a condition.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// No element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// More than one element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// The source sequence is empty.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<TSource> SingleAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
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
        long count = 0;
        foreach (var element in source)
        {
            if (await predicate(element, token))
            {
                result = element;
                checked { count++; }
            }
            token.ThrowIfCancellationRequested();
        }
        switch (count)
        {
            case 0: throw new InvalidOperationException(FluentMethods.Strings.NoMatch);
            case 1: return result;
            default: throw new InvalidOperationException(FluentMethods.Strings.MoreThanOneMatch);
        }
    }

    /// <summary>
    /// Asynchronously returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the single element of the input sequence that satisfies a condition.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// No element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// More than one element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// The source sequence is empty.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<TSource> SingleAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken token)
    {
        return source.SingleAsync(async (x, t) => await predicate(x), token);
    }

    /// <summary>
    /// Asynchronously returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the single element of the input sequence that satisfies a condition.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// No element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// More than one element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// The source sequence is empty.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<TSource> SingleAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
    {
        return source.SingleAsync(predicate, CancellationToken.None);
    }
}