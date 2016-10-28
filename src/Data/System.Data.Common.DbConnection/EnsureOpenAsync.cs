using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    ///     Asynchronously ensures the specified <see cref="DbConnection"/> opens.
    /// </summary>
    /// <param name="connection">The connection to act on.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="connection"/> is <see langword="null" />.
    /// </exception>
    public static async Task EnsureOpenAsync(this DbConnection connection, CancellationToken token)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
        }
        if (connection.State == ConnectionState.Closed)
        {
            await connection.OpenAsync(token);
        }
    }
    /// <summary>
    ///     Asynchronously ensures the specified <see cref="DbConnection"/> opens.
    /// </summary>
    /// <param name="connection">The connection to act on.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="connection"/> is <see langword="null" />.
    /// </exception>
    public static Task EnsureOpenAsync(this DbConnection connection)
    {
        return connection.EnsureOpenAsync(CancellationToken.None);
    }
}