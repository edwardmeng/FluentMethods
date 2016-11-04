using System;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Create a lambda expression that represents a conditional <c>OR</c> operation to compose the lambda expression operands.
    /// </summary>
    /// <typeparam name="T">The type of the lambda expression represents.</typeparam>
    /// <param name="left">The lambda expression that represents the left operand.</param>
    /// <param name="right">The lambda expression that represents the right operand.</param>
    /// <returns>A lambda expression that compose the left and right operands with conditional <c>OR</c> operation.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The conditional <c>OR</c> operator is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.</exception>
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
#if Net35
        var param = left.Parameters[0];
        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, Expression.Invoke(right, param)), param);
#else
        return left.Compose(right, Expression.OrElse);
#endif
    }

    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents a conditional <c>OR</c> operation that evaluates the second operand only if the first operand evaluates to <c>false</c>.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the conditional <c>OR</c> operation of the left and right operands.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The conditional <c>OR</c> operator is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.</exception>
    public static BinaryExpression Or(this Expression left, Expression right)
    {
        return Expression.OrElse(left, right);
    }
}