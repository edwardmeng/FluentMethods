using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

/// <summary>
/// A fluent <see langword="interface"/> to build log messages.
/// </summary>
[DebuggerStepThrough]
public class LogBuilder
{
    private readonly LogLevel _logLevel;
    private EventId _eventId;
    private Exception _exception;
    private string _message;
    private Func<string> _messageFormatter;
    private object[] _arguments;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogBuilder" /> class.
    /// </summary>
    /// <param name="logLevel">The starting trace level.</param>
    /// <param name="logger">The delegate to write logs to.</param>
    /// <exception cref="System.ArgumentNullException">writer</exception>
    internal LogBuilder(ILogger logger, LogLevel logLevel)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger));

        _logger = logger;
        _logLevel = logLevel;
    }

    /// <summary>
    /// Sets the id of the logging event.
    /// </summary>
    /// <param name="eventId">The id of the logging event.</param>
    /// <returns></returns>
    public LogBuilder EventId(EventId eventId)
    {
        _eventId = eventId;
        return this;
    }

    /// <summary>
    /// Sets the log message on the logging event.
    /// </summary>
    /// <param name="message">The log message for the logging event.</param>
    /// <returns></returns>
    public LogBuilder Message(string message)
    {
        _message = message;
        return this;
    }

    /// <summary>
    /// Sets the log message on the logging event.
    /// </summary>
    /// <param name="messageFormatter">The message formatter <see langword="delegate"/>.</param>
    /// <returns></returns>
    public LogBuilder Message(Func<string> messageFormatter)
    {
        _messageFormatter = messageFormatter;
        return this;
    }

    /// <summary>
    /// Sets the log message and parameters for formating on the logging event.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arg0">The object to format.</param>
    /// <returns></returns>
    public LogBuilder Message(string format, object arg0)
    {
        _message = format;
        _arguments = new[] { arg0 };
        return this;
    }

    /// <summary>
    /// Sets the log message and parameters for formating on the logging event.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arg0">The first object to format.</param>
    /// <param name="arg1">The second object to format.</param>
    /// <returns></returns>
    public LogBuilder Message(string format, object arg0, object arg1)
    {
        _message = format;
        _arguments = new[] { arg0, arg1 };
        return this;
    }

    /// <summary>
    /// Sets the log message and parameters for formating on the logging event.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arg0">The first object to format.</param>
    /// <param name="arg1">The second object to format.</param>
    /// <param name="arg2">The third object to format.</param>
    /// <returns></returns>
    public LogBuilder Message(string format, object arg0, object arg1, object arg2)
    {
        _message = format;
        _arguments = new[] { arg0, arg1, arg2 };
        return this;
    }

    /// <summary>
    /// Sets the log message and parameters for formating on the logging event.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    /// <returns></returns>
    public LogBuilder Message(string format, params object[] args)
    {
        _message = format;
        _arguments = args;
        return this;
    }

    /// <summary>
    /// Sets the exception information of the logging event.
    /// </summary>
    /// <param name="exception">The exception information of the logging event.</param>
    /// <returns></returns>
    public LogBuilder Exception(Exception exception)
    {
        _exception = exception;
        return this;
    }

    private string GetMessage()
    {
        if (_messageFormatter != null)
        {
            return _messageFormatter();
        }
        if (_arguments != null && _arguments.Length > 0)
            return string.Format(_message, _arguments);
        return _message;
    }

    /// <summary>
    /// Writes the log event to the underlying logger.
    /// </summary>
    /// <param name="formatter">Function to create a string message of the original message and exception.</param>
    /// <param name="callerMemberName">The method or property name of the caller to the method. This is set at by the compiler.</param>
    /// <param name="callerFilePath">The full path of the source file that contains the caller. This is set at by the compiler.</param>
    /// <param name="callerLineNumber">The line number in the source file at which the method is called. This is set at by the compiler.</param>
    public void Write(Func<string, Exception, string> formatter,
        [CallerMemberName] string callerMemberName = null,
        [CallerFilePath] string callerFilePath = null,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        if (!_logger.IsEnabled(_logLevel)) return;
        var message = new StringBuilder();
        if (!string.IsNullOrEmpty(callerFilePath) && !string.IsNullOrEmpty(callerMemberName))
            message
                .Append("[")
                .Append(Path.GetFileName(callerFilePath))
                .Append(" ")
                .Append(callerMemberName)
                .Append("()")
                .Append(" Ln: ")
                .Append(callerLineNumber)
                .Append("] ");
        message.Append(GetMessage());
        _logger.Log(_logLevel, _eventId, message, _exception, (state, error) => formatter(state.ToString(), error));
    }

    /// <summary>
    /// Writes the log event to the underlying logger.
    /// </summary>
    /// <param name="callerMemberName">The method or property name of the caller to the method. This is set at by the compiler.</param>
    /// <param name="callerFilePath">The full path of the source file that contains the caller. This is set at by the compiler.</param>
    /// <param name="callerLineNumber">The line number in the source file at which the method is called. This is set at by the compiler.</param>
    public void Write(
        [CallerMemberName]string callerMemberName = null,
        [CallerFilePath]string callerFilePath = null,
        [CallerLineNumber]int callerLineNumber = 0)
    {
        Write((state, error) =>
        {
            var message = new StringBuilder(state);
            if (error != null)
            {
                if (!string.IsNullOrEmpty(state))
                {
                    message.AppendLine();
                }
                message.Append(error);
            }
            return message.ToString();
        });
    }

    /// <summary>
    /// Writes the log event to the underlying logger if the condition delegate is true.
    /// </summary>
    /// <param name="condition">If condition is true, write log event; otherwise ignore event.</param>
    /// <param name="formatter">Function to create a string message of the original message and exception.</param>
    /// <param name="callerMemberName">The method or property name of the caller to the method. This is set at by the compiler.</param>
    /// <param name="callerFilePath">The full path of the source file that contains the caller. This is set at by the compiler.</param>
    /// <param name="callerLineNumber">The line number in the source file at which the method is called. This is set at by the compiler.</param>
    public void WriteIf(
        Func<bool> condition, Func<string, Exception, string> formatter,
        [CallerMemberName]string callerMemberName = null,
        [CallerFilePath]string callerFilePath = null,
        [CallerLineNumber]int callerLineNumber = 0)
    {
        if (condition == null || !condition())
            return;

        Write(callerMemberName, callerFilePath, callerLineNumber);
    }

    /// <summary>
    /// Writes the log event to the underlying logger if the condition delegate is true.
    /// </summary>
    /// <param name="condition">If condition is true, write log event; otherwise ignore event.</param>
    /// <param name="callerMemberName">The method or property name of the caller to the method. This is set at by the compiler.</param>
    /// <param name="callerFilePath">The full path of the source file that contains the caller. This is set at by the compiler.</param>
    /// <param name="callerLineNumber">The line number in the source file at which the method is called. This is set at by the compiler.</param>
    public void WriteIf(
        Func<bool> condition,
        [CallerMemberName]string callerMemberName = null,
        [CallerFilePath]string callerFilePath = null,
        [CallerLineNumber]int callerLineNumber = 0)
    {
        if (condition == null || !condition())
            return;

        Write(callerMemberName, callerFilePath, callerLineNumber);
    }

    /// <summary>
    /// Writes the log event to the underlying logger if the condition is true.
    /// </summary>
    /// <param name="condition">If condition is true, write log event; otherwise ignore event.</param>
    /// <param name="formatter">Function to create a string message of the original message and exception.</param>
    /// <param name="callerMemberName">The method or property name of the caller to the method. This is set at by the compiler.</param>
    /// <param name="callerFilePath">The full path of the source file that contains the caller. This is set at by the compiler.</param>
    /// <param name="callerLineNumber">The line number in the source file at which the method is called. This is set at by the compiler.</param>
    public void WriteIf(
        bool condition, Func<string, Exception, string> formatter,
        [CallerMemberName]string callerMemberName = null,
        [CallerFilePath]string callerFilePath = null,
        [CallerLineNumber]int callerLineNumber = 0)
    {
        if (!condition)
            return;

        Write(callerMemberName, callerFilePath, callerLineNumber);
    }

    /// <summary>
    /// Writes the log event to the underlying logger if the condition is true.
    /// </summary>
    /// <param name="condition">If condition is true, write log event; otherwise ignore event.</param>
    /// <param name="callerMemberName">The method or property name of the caller to the method. This is set at by the compiler.</param>
    /// <param name="callerFilePath">The full path of the source file that contains the caller. This is set at by the compiler.</param>
    /// <param name="callerLineNumber">The line number in the source file at which the method is called. This is set at by the compiler.</param>
    public void WriteIf(
        bool condition,
        [CallerMemberName]string callerMemberName = null,
        [CallerFilePath]string callerFilePath = null,
        [CallerLineNumber]int callerLineNumber = 0)
    {
        if (!condition)
            return;

        Write(callerMemberName, callerFilePath, callerLineNumber);
    }
}
