using System;
using System.Data;

public static partial class Extensions
{
    /// <summary>
    ///     An IDbConnection extension method that ensures that open.
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