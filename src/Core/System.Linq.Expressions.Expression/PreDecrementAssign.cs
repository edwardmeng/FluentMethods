using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that decrements the expression by 1 and assigns the result back to the expression.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> to apply the operations on.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents the resultant expression.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression PreDecrementAssign(this Expression expression)
    {
        return Expression.PreDecrementAssign(expression);
    }
}