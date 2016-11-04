using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents a throwing of an exception.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> that represents the exception to throw.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents the exception.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression Throw(this Expression expression)
    {
        return Expression.Throw(expression);
    }
}