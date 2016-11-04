using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents raising a number to a power.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents raising a number to a power.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// The exponentiation operator is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.
    /// -or-
    /// The type of <paramref name="left"/> and/or <paramref name="right"/> are not <see cref="double"/>.
    /// </exception>
    public static BinaryExpression Power(this Expression left, Expression right)
    {
        return Expression.Power(left, right);
    }
}