using System;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
    /// </summary>
    /// <param name="source">An <see cref="IQueryable"/> to return elements from.</param>
    /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
    /// <returns>An <see cref="IQueryable"/> that contains elements that occur after the specified index in the input sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IQueryable Skip(this IQueryable source, int count)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Skip", new[] { source.ElementType }, source.Expression, Expression.Constant(count)));
    }
}