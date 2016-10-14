using System;
using System.Collections.Generic;
using System.Diagnostics;

public static partial class Extensions
{

    /// <summary>
    /// Performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The sequence that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <remarks>
    /// This method was intended to return the passed values to provide method chaining. 
    /// However due to defered execution the compiler would actually never run the entire code at all.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        foreach (var value in source)
        {
            action(value);
        }
    }

    /// <summary>
    /// Performs an action for each item in the enumerable
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The data values.</param>
    /// <param name="action">The action to be performed.</param>
    /// <remarks>
    /// This method was intended to return the passed values to provide method chaining. 
    /// However due to defered execution the compiler would actually never run the entire code at all.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        var index = 0;
        foreach (var value in source)
        {
            action(value, index);
            index++;
        }
    }
}