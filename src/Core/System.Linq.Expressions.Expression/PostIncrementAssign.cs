using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents the assignment of the expression followed by a subsequent increment by 1 of the original expression.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> to apply the operations on.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents the resultant expression.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression PostIncrementAssign(this Expression expression)
    {
        return Expression.PostIncrementAssign(expression);
    }
}