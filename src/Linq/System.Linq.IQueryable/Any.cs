using System;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Determines whether a sequence contains any elements.
    /// </summary>
    /// <param name="source">A sequence to check for being empty.</param>
    /// <returns><c>true</c> if the source sequence contains any elements; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static bool Any(this IQueryable source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return source.Provider.Execute<bool>(Expression.Call(typeof(Queryable), "Any", new[] { source.ElementType }, source.Expression));
    }
}