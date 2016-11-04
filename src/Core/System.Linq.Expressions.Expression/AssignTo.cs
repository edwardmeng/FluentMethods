using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents an assignment operation.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the assignment operation.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    public static BinaryExpression AssignTo(this Expression right, Expression left)
    {
        return Expression.Assign(left, right);
    }
}