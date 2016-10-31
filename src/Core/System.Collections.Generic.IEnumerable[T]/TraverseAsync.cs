using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously performs an action for each item in the hierarchy
    /// </summary>
    /// <typeparam name="T">The hierarchy data type</typeparam>
    /// <param name="source">The hierarchy that the action to be performed for.</param>
    /// <param name="childrenFactory">The factory to retrieve child items.</param>
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
    /// <paramref name="source"/>, <paramref name="childrenFactory"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenFactory, Func<T, Task> action, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (childrenFactory == null)
        {
            throw new ArgumentNullException(nameof(childrenFactory));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        foreach (var v in source)
        {
            await action(v);
            await TraverseAsync(childrenFactory(v), childrenFactory, action, token);
        }
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the hierarchy
    /// </summary>
    /// <typeparam name="T">The hierarchy data type</typeparam>
    /// <param name="source">The hierarchy that the action to be performed for.</param>
    /// <param name="childrenFactory">The factory to retrieve child items.</param>
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
    /// <paramref name="source"/>, <paramref name="childrenFactory"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenFactory, Func<T, Task> action)
    {
        return source.TraverseAsync(childrenFactory, action, CancellationToken.None);
    }
}