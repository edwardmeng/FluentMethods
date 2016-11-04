using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents a subtraction assignment operation that does not have overflow checking.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the subtraction assignment operation of the left and right operand.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The subtraction operator is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.</exception>
    public static BinaryExpression SubtractAssign(this Expression left, Expression right)
    {
        return Expression.SubtractAssign(left, right);
    }
}