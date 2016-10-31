using System;
using System.Data;

public static partial class Extensions
{
    /// <summary>
    ///     Ensures the specified <see cref="IDbConnection"/> opens
    /// </summary>
    /// <param name="connection">The connection to act on.</param>
    public static void EnsureOpen(this IDbConnection connection)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
        }
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
    }
}