using Microsoft.Extensions.Logging;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="LogBuilder"/> to build a critical level log entry.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <returns>The <see cref="LogBuilder"/> to build log entry.</returns>
    public static LogBuilder Critical(this ILogger logger)
    {
        return new LogBuilder(logger, LogLevel.Critical);
    }
}