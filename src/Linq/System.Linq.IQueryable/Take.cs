using System;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Returns a specified number of contiguous elements from the start of a sequence.
    /// </summary>
    /// <param name="source">The sequence to return elements from.</param>
    /// <param name="count">The number of elements to return.</param>
    /// <returns>
    /// An <see cref="IQueryable"/> that contains the specified number of elements from the start of <paramref name="source"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IQueryable Take(this IQueryable source, int count)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Take", new[] { source.ElementType }, source.Expression, Expression.Constant(count)));
    }
}