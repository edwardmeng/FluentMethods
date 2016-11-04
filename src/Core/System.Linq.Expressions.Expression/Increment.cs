using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents the incrementing of the expression by 1.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> to increment.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents the incremented expression.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression Increment(this Expression expression)
    {
        return Expression.Increment(expression);
    }
}