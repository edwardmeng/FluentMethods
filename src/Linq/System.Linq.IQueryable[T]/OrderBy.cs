using System;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Sorts the elements of a sequence according with a specified expression.
    /// </summary>
    /// <param name="source">A sequence of values to order.</param>
    /// <param name="ordering">An expression to sort elements in the <paramref name="source"/>.</param>
    /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according by using the <paramref name="ordering"/> expression.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="ordering"/> is <see langword="null"/> or empty string("").</exception>
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return (IOrderedQueryable<T>) ((IQueryable) source).OrderBy(ordering);
    }
}