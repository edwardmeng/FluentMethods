using System;
using System.Data;

public static partial class Extensions
{
    /// <summary>
    ///     A IDbCommand extension method that executes the scalar as or default operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="command">The command to act on.</param>
    /// <param name="defaultValueFactory">The default value factory.</param>
    /// <returns>A T.</returns>
    public static T ExecuteScalarOrDefault<T>(this IDbCommand command, Func<IDbCommand, T> defaultValueFactory)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        return (T)(command.ExecuteScalar() ?? defaultValueFactory(command));
    }

    /// <summary>
    ///     A DbCommand extension method that executes the scalar as or default operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="command">The command to act on.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>A T.</returns>
    public static T ExecuteScalarOrDefault<T>(this IDbCommand command, T defaultValue)
    {
        return command.ExecuteScalarOrDefault(x => defaultValue);
    }

    /// <summary>
    ///     A DbCommand extension method that executes the scalar as or default operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="command">The command to act on.</param>
    /// <returns>A T.</returns>
    public static T ExecuteScalarOrDefault<T>(this IDbCommand command)
    {
        return command.ExecuteScalarOrDefault(default(T));
    }
}