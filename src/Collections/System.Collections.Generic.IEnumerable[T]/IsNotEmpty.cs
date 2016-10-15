using System.Collections.Generic;
using System.Diagnostics;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether the specified enumerable is not empty.
    /// </summary>
    /// <typeparam name="T">The enumerable data type</typeparam>
    /// <param name="source">The enumerable object. It can be null.</param>
    /// <returns><c>true</c> if the <paramref name="source"/> parameter is not empty; otherwise, false.</returns>
    [DebuggerStepThrough]
    public static bool IsNotEmpty<T>(this IEnumerable<T> source)
    {
        return source != null && !source.IsEmpty();
    }
}