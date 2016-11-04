using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents an expression for obtaining the length of a one-dimensional array.
    /// </summary>
    /// <param name="array">An expression that represents the array.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents an expression for obtaining the length of the array.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The <paramref name="array"/> does not represent an array type.</exception>
    public static UnaryExpression ArrayLength(this Expression array)
    {
        return Expression.ArrayLength(array);
    }
}