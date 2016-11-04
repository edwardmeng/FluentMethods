﻿using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents a bitwise <c>OR</c> operation.
    /// </summary>
    /// <param name="left">A <see cref="Expression"/> that represents the left operand.</param>
    /// <param name="right">A <see cref="Expression"/> that represents the right operand.</param>
    /// <returns>A <see cref="BinaryExpression"/> represents the bitwise <c>OR</c> operation of the left and right operand.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The bitwise <c>OR</c> operator is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.</exception>
    public static BinaryExpression BitwiseOr(this Expression left, Expression right)
    {
        return Expression.Or(left, right);
    }
}