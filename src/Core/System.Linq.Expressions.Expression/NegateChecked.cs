using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents an arithmetic negation operation that has overflow checking.
    /// </summary>
    /// <param name="expression">The <see cref="Expression"/> to perform the negation operation.</param>
    /// <returns>A <see cref="UnaryExpression"/> represents the arithmetic negation operation of the <paramref name="expression"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The unary minus operator is not defined for the type of <paramref name="expression"/>.</exception>
    public static UnaryExpression NegateChecked(this Expression expression)
    {
        return Expression.NegateChecked(expression);
    }
}