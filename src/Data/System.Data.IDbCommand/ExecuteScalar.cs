using System;
using System.Data.Common;

public static partial class Extensions
{
    /// <summary>
    ///     A DbCommand extension method that executes the scalar operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="command">The command to act on.</param>
    /// <returns>A T.</returns>
    public static T ExecuteScalar<T>(this DbCommand command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        return (T)command.ExecuteScalar();
    }
}