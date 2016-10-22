using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously returns the last element of a sequence that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the last element in the sequence that passes the test in the specified predicate function.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// No element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// The source sequence is empty.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<TSource> LastAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<bool>> predicate, CancellationToken token)
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
        bool found = false;
        foreach (var element in source)
        {
            if (await predicate(element, token))
            {
                result = element;
                found = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (found) return result;
        throw new InvalidOperationException(Strings.NoMatch);
    }

    /// <summary>
    /// Asynchronously returns the last element of a sequence that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the last element in the sequence that passes the test in the specified predicate function.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// No element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// The source sequence is empty.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<TSource> LastAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken token)
    {
        return source.LastAsync(async (x, t) => await predicate(x), token);
    }

    /// <summary>
    /// Asynchronously returns the last element of a sequence that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the last element in the sequence that passes the test in the specified predicate function.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// No element satisfies the condition in <paramref name="predicate"/>.
    /// -or-
    /// The source sequence is empty.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<TSource> LastAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
    {
        return source.LastAsync(predicate, CancellationToken.None);
    }
}