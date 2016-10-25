using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task TraverseAsync(this Array array, Func<object, int[], CancellationToken, Task> action, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
#if NetCore
        if (array.Length == 0) return;
#else
        if (array.LongLength == 0) return;
#endif
        var traverser = new ArrayTraverse(array);
        while (traverser.MoveNext())
        {
            await action(array.GetValue(traverser.Indices), traverser.Indices, token);
            token.ThrowIfCancellationRequested();
        }
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync(this Array array, Func<object, int[], Task> action, CancellationToken token)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        return array.TraverseAsync((x, i, t) => action(x, i), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync(this Array array, Func<object, int[], Task> action)
    {
        return array.TraverseAsync(action, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync(this Array array, Func<object, CancellationToken, Task> action, CancellationToken token)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        return array.TraverseAsync((element, indices, cancellationToken) => action(element, cancellationToken), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync(this Array array, Func<object, Task> action, CancellationToken token)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        return array.TraverseAsync((object element, CancellationToken cancellationToken) => action(element), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync(this Array array, Func<object, Task> action)
    {
        return array.TraverseAsync(action, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this Array array, Func<T, int[], CancellationToken, Task> action, CancellationToken token)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        return array.TraverseAsync((x, i, t) => action((T)x, i, t), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this Array array, Func<T, int[], Task> action, CancellationToken token)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        return array.TraverseAsync<T>((x, i, t) => action(x, i), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this Array array, Func<T, int[], Task> action)
    {
        return array.TraverseAsync(action, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this Array array, Func<T, CancellationToken, Task> action, CancellationToken token)
    {
        return array.TraverseAsync((x, cancellationToken) => action((T)x, cancellationToken), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this Array array, Func<T, Task> action, CancellationToken token)
    {
        return array.TraverseAsync((T x, CancellationToken cancellationToken) => action(x), token);
    }

    /// <summary>
    /// Asynchronously performs an action for each item in the array.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task TraverseAsync<T>(this Array array, Func<T, Task> action)
    {
        return array.TraverseAsync(action, CancellationToken.None);
    }
}