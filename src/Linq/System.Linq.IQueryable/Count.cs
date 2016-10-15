using System;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Returns the number of elements in a sequence.
    /// </summary>
    /// <param name="source">The <see cref="IQueryable"/> that contains the elements to be counted.</param>
    /// <returns>The number of elements in the input sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static int Count(this IQueryable source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return (int)source.Provider.Execute(Expression.Call(typeof(Queryable), "Count", new[] { source.ElementType }, source.Expression));
    }
}