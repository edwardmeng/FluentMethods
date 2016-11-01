using System;
using System.Collections.Generic;
using System.Diagnostics;

public static partial class Extensions
{
    /// <summary>
    /// Performs an action for each item in the hierarchy
    /// </summary>
    /// <typeparam name="T">The hierarchy data type</typeparam>
    /// <param name="source">The hierarchy that the action to be performed for.</param>
    /// <param name="childrenFactory">The factory to retrieve child items.</param>
    /// <param name="action">The action to be performed.</param>
    /// <remarks>
    /// This method was intended to return the passed values to provide method chaining. 
    /// However due to defered execution the compiler would actually never run the entire code at all.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/>, <paramref name="childrenFactory"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static void Traverse<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenFactory, Action<T> action)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (childrenFactory == null)
        {
            throw new ArgumentNullException(nameof(childrenFactory));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        foreach (var v in source)
        {
            action(v);
            var children = childrenFactory(v);
            if (children != null)
            {
                Traverse(children, childrenFactory, action);
            }
        }
    }
}