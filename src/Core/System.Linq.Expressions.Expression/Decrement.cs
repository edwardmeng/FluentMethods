using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents the decrementing of the expression by 1.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> to decrement.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents the decremented expression.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression Decrement(this Expression expression)
    {
        return Expression.Decrement(expression);
    }
}