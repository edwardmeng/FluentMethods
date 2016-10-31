using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a read-only wrapper for the specified <see cref="IList{T}"/>.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="collection">The collection to act on.</param>
    /// <returns>A read-only <see cref="IList{T}"/> wrapper for the specified <see cref="IList{T}"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is null.</exception>
    public static IList<T> AsReadOnly<T>(this IList<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        return new ReadOnlyCollection<T>(collection);
    }
}