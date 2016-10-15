using System;
using System.Linq;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Paginate the elements in the source.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IQueryable{TSource}"/> to paginate.</param>
    /// <param name="pageIndex">The zero-based index at which page the paginate starts.</param>
    /// <param name="pageSize">The number of elements in the page.</param>
    /// <returns>An <see cref="IQueryable{T}"/> that contains elements from the input sequence that paginated by using the <paramref name="pageIndex"/> and <paramref name="pageSize"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="pageIndex"/> or <paramref name="pageSize"/> is negative number.
    /// </exception>
    public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int pageIndex, int pageSize)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (pageIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageIndex), Strings.NeedNonNegNum);
        }
        if (pageSize < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), Strings.NeedNonNegNum);
        }
        var query = source;
        if (pageIndex > 0 && pageSize != int.MaxValue)
        {
            query = Queryable.Skip(query, pageIndex * pageSize);
        }
        if (pageSize != int.MaxValue)
        {
            query = Queryable.Take(query, pageSize);
        }
        return query;
    }
}