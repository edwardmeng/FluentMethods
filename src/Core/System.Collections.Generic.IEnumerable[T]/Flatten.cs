using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Produces an new <see cref="IEnumerable{T}"/> to flatten a nested sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The nested sequence to flatten.</param>
    /// <returns>The flatten sequence of nested sequence.</returns>
    public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        return source.SelectMany(e => e);
    }
}