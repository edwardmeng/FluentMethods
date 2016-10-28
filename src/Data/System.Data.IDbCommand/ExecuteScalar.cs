using System;
using System.Data;

public static partial class Extensions
{
    /// <summary>
    ///     Executes the command scalar operation.
    /// </summary>
    /// <typeparam name="T">The type of return value.</typeparam>
    /// <param name="command">The command to be executed.</param>
    /// <returns>The scalar value.</returns>
    public static T ExecuteScalar<T>(this IDbCommand command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        return (T)command.ExecuteScalar();
    }
}