using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents an expression that has a constant value of type <see cref="Expression"/>.
    /// </summary>
    /// <param name="expression">The <see cref="Expression"/> to perform the quote operation.</param>
    /// <returns>A <see cref="UnaryExpression"/> represents the quote operation of the <paramref name="expression"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static UnaryExpression Quote(this Expression expression)
    {
        return Expression.Quote(expression);
    }
}