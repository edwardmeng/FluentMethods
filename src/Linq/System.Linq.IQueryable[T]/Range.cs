using System;
using System.Linq;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Limit range of elements in the source.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IQueryable{T}"/> to limit.</param>
    /// <param name="index">The zero-based index at which the range starts.</param>
    /// <param name="count">The number of elements in the range.</param>
    /// <returns>An <see cref="IQueryable{T}"/> that contains elements from the input sequence that limit the elements through the specified range.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index"/> or <paramref name="count"/> is negative number.
    /// </exception>
    public static IQueryable<TSource> Range<TSource>(this IQueryable<TSource> source, int index, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), Strings.NeedNonNegNum);
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), Strings.NeedNonNegNum);
        }
        var query = source;
        if (index > 0)
        {
            query = query.Skip(index);
        }
        if (count != int.MaxValue)
        {
            query = query.Take(count);
        }
        return query;
    }
}