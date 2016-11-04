using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Returns whether the expression evaluates to <c>false</c>.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> to evaluate.</param>
    /// <returns>An instance of <see cref="UnaryExpression"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression IsFalse(this Expression expression)
    {
        return Expression.IsFalse(expression);
    }
}