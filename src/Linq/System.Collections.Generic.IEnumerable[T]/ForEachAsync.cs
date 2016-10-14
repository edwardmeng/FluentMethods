using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The sequence that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         Multiple active operations on the same context instance are not supported. 
    ///         Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    ///     </para>
    ///     <para>
    ///         This method was intended to return the passed values to provide method chaining. 
    ///         However due to defered execution the compiler would actually never run the entire code at all.
    ///     </para>
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, CancellationToken, Task> action, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        foreach (var value in source)
        {
            await action(value, token);
            token.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The sequence that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         Multiple active operations on the same context instance are not supported. 
    ///         Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    ///     </para>
    ///     <para>
    ///         This method was intended to return the passed values to provide method chaining. 
    ///         However due to defered execution the compiler would actually never run the entire code at all.
    ///     </para>
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action, CancellationToken token)
    {
        return source.ForEachAsync(async (T x, CancellationToken t) => await action(x), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The sequence that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         Multiple active operations on the same context instance are not supported. 
    ///         Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    ///     </para>
    ///     <para>
    ///         This method was intended to return the passed values to provide method chaining. 
    ///         However due to defered execution the compiler would actually never run the entire code at all.
    ///     </para>
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
    {
        return source.ForEachAsync(action, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The data values.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         Multiple active operations on the same context instance are not supported. 
    ///         Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    ///     </para>
    ///     <para>
    ///         This method was intended to return the passed values to provide method chaining. 
    ///         However due to defered execution the compiler would actually never run the entire code at all.
    ///     </para>
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, int, CancellationToken, Task> action, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        var index = 0;
        foreach (var value in source)
        {
            await action(value, index, token);
            index++;
            token.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The data values.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         Multiple active operations on the same context instance are not supported. 
    ///         Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    ///     </para>
    ///     <para>
    ///         This method was intended to return the passed values to provide method chaining. 
    ///         However due to defered execution the compiler would actually never run the entire code at all.
    ///     </para>
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, int, Task> action, CancellationToken token)
    {
        return source.ForEachAsync(async (x, i, t) => await action(x, i), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The data values.</param>
    /// <param name="action">The action to be performed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         Multiple active operations on the same context instance are not supported. 
    ///         Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    ///     </para>
    ///     <para>
    ///         This method was intended to return the passed values to provide method chaining. 
    ///         However due to defered execution the compiler would actually never run the entire code at all.
    ///     </para>
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, int, Task> action)
    {
        return source.ForEachAsync(action, CancellationToken.None);
    }
}