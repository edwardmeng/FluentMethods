using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents a coalescing operation.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the coalescing operation of the left and right operand.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The type of <paramref name="left"/> and <paramref name="right"/> are not convertible to each other.</exception>
    /// <exception cref="System.InvalidOperationException">The type of left does not represent a reference type or a nullable value type.</exception>
    public static BinaryExpression Coalesce(this Expression left, Expression right)
    {
        return Expression.Coalesce(left, right);
    }
}