using System;
using System.Linq;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Paginate the elements in the source.
    /// </summary>
    /// <param name="source">An <see cref="IQueryable"/> to paginate.</param>
    /// <param name="pageIndex">The zero-based index at which page the paginate starts.</param>
    /// <param name="pageSize">The number of elements in the page.</param>
    /// <returns>An <see cref="IQueryable"/> that contains elements from the input sequence that paginated by using the <paramref name="pageIndex"/> and <paramref name="pageSize"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="pageIndex"/> or <paramref name="pageSize"/> is negative number.
    /// </exception>
    public static IQueryable Paginate(this IQueryable source, int pageIndex, int pageSize)
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
            query = query.Skip(pageIndex * pageSize);
        }
        if (pageSize != int.MaxValue)
        {
            query = query.Take(pageSize);
        }
        return query;
    }
}