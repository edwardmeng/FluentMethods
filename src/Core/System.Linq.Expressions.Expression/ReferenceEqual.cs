using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents a reference equality comparison.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the reference equality comparison of the left and right operand.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    public static BinaryExpression ReferenceEqual(this Expression left, Expression right)
    {
        return Expression.ReferenceEqual(left, right);
    }

}