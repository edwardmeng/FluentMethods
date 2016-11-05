using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents a bitwise not operation.
    /// </summary>
    /// <param name="expression">The <see cref="Expression"/> to perform the bitwise not operation.</param>
    /// <returns>A <see cref="UnaryExpression"/> represents the bitwise not operation of the <paramref name="expression"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The unary not operator is not defined for the type of <paramref name="expression"/>.</exception>
    public static UnaryExpression Not(this Expression expression)
    {
        return Expression.Not(expression);
    }
}