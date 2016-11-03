using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    ///     Asynchronously executes the command scalar operation.
    /// </summary>
    /// <typeparam name="T">The type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> is <see langword="null" />.
    /// </exception>
    public static async Task<T> ExecuteScalarAsync<T>(this DbCommand command, CancellationToken token)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        return (await command.ExecuteScalarAsync(token)).To<T>();
    }

    /// <summary>
    ///     Asynchronously executes the command scalar operation.
    /// </summary>
    /// <typeparam name="T">The type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the scalar value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="command"/> is <see langword="null" />.
    /// </exception>
    public static Task<T> ExecuteScalarAsync<T>(this DbCommand command)
    {
        return command.ExecuteScalarAsync<T>(CancellationToken.None);
    }
}