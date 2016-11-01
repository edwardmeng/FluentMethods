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
    public static async Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, CancellationToken, Task<IEnumerable<T>>> childrenFactory, Func<T, CancellationToken, Task> action, CancellationToken token)
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
            await action(v, token);
            var children = await childrenFactory(v, token);
            token.ThrowIfCancellationRequested();
            if (children != null)
            {
                await TraverseAsync(children, childrenFactory, action, token);
            }
        }
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, CancellationToken, Task<IEnumerable<T>>> childrenFactory, Func<T, Task> action, CancellationToken token)
    {
        return source.TraverseAsync(childrenFactory, (x, t) => action(x), token);
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, CancellationToken, Task<IEnumerable<T>>> childrenFactory, Action<T> action, CancellationToken token)
    {
        return source.TraverseAsync(childrenFactory, (x, t) =>
        {
#if Net40
            return Task.Factory.StartNew(() => action(x), t);
#else
            action(x);
            return Task.Delay(0, t);
#endif
        }, token);
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, Task<IEnumerable<T>>> childrenFactory, Func<T, CancellationToken, Task> action, CancellationToken token)
    {
        return source.TraverseAsync((x, t) => childrenFactory(x), action, token);
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, Task<IEnumerable<T>>> childrenFactory, Func<T, Task> action, CancellationToken token)
    {
        return source.TraverseAsync((x, t) => childrenFactory(x), action, token);
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, Task<IEnumerable<T>>> childrenFactory, Action<T> action, CancellationToken token)
    {
        return source.TraverseAsync((x, t) => childrenFactory(x), action, token);
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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, Task<IEnumerable<T>>> childrenFactory, Func<T, Task> action)
    {
        return source.TraverseAsync(childrenFactory, action, CancellationToken.None);
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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, Task<IEnumerable<T>>> childrenFactory, Action<T> action)
    {
        return source.TraverseAsync(childrenFactory, action, CancellationToken.None);
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenFactory, Func<T, CancellationToken, Task> action, CancellationToken token)
    {
        return source.TraverseAsync((x, t) =>
        {
#if Net40
            return Task.Factory.StartNew(() => childrenFactory(x), t);
#else
            return Task.FromResult(childrenFactory(x));
#endif
        }, action, token);
    }

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
    public static Task TraverseAsync<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenFactory, Func<T, Task> action, CancellationToken token)
    {
        return source.TraverseAsync(childrenFactory, (x, t) => action(x), token);
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