using System.Collections.Generic;
using System.Diagnostics;

public static partial class Extensions
{
    /// <summary>
    ///     Concatenates all the elements of a IEnumerable, using the specified separator between each element.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> that contains the elements to concatenate.</param>
    /// <param name="separator">
    ///     The string to use as a separator. separator is included in the returned string only if
    ///     value has more than one element.
    /// </param>
    /// <returns>
    ///     A string that consists of the elements in value delimited by the separator string. If value is an empty array,
    ///     the method returns String.Empty.
    /// </returns>
    [DebuggerStepThrough]
    public static string Join<T>(this IEnumerable<T> source, string separator)
    {
        return string.Join(separator, source);
    }
}