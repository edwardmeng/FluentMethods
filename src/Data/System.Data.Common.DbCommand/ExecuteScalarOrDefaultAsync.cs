using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> or <paramref name="defaultValueFactory"/> is <see langword="null" />.
    /// </exception>
    public static async Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command, Func<IDbCommand, CancellationToken, Task<T>> defaultValueFactory, CancellationToken token)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        if (defaultValueFactory == null)
        {
            throw new ArgumentNullException(nameof(defaultValueFactory));
        }
        return (T)(await command.ExecuteScalarAsync(token) ?? await defaultValueFactory(command, token));
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> or <paramref name="defaultValueFactory"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command, Func<IDbCommand, Task<T>> defaultValueFactory, CancellationToken token)
    {
        if (defaultValueFactory == null)
        {
            throw new ArgumentNullException(nameof(defaultValueFactory));
        }
        return command.ExecuteScalarOrDefaultAsync((x, t) => defaultValueFactory(x), token);
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> or <paramref name="defaultValueFactory"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command, Func<IDbCommand, Task<T>> defaultValueFactory)
    {
        return command.ExecuteScalarOrDefaultAsync(defaultValueFactory, CancellationToken.None);
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> or <paramref name="defaultValueFactory"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command, Func<IDbCommand, T> defaultValueFactory, CancellationToken token)
    {
        if (defaultValueFactory == null)
        {
            throw new ArgumentNullException(nameof(defaultValueFactory));
        }
        return command.ExecuteScalarOrDefaultAsync((x, t) => Task.FromResult(defaultValueFactory(x)), token);
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> or <paramref name="defaultValueFactory"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command, Func<IDbCommand, T> defaultValueFactory)
    {
        return command.ExecuteScalarOrDefaultAsync(defaultValueFactory, CancellationToken.None);
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command, T defaultValue)
    {
        return command.ExecuteScalarOrDefaultAsync(x => defaultValue);
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation and return the strong typed value or default value.
    /// </summary>
    /// <typeparam name="T">Type type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarOrDefaultAsync<T>(this DbCommand command)
    {
        return command.ExecuteScalarOrDefaultAsync(default(T));
    }
}