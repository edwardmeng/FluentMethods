using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents an arithmetic remainder operation.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> to set the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> to set the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the arithmetic remainder operation of the left and right operand.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The modulus operator is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.</exception>
    public static BinaryExpression Modulo(this Expression left, Expression right)
    {
        return Expression.Modulo(left, right);
    }
}