using System;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="TypeBinaryExpression"/> that represents the specified type checking.
    /// </summary>
    /// <param name="expression">An <see cref="Expression"/> whose type to be checked.</param>
    /// <param name="type">The <see cref="Type"/> to check the type of the <paramref name="expression"/>.</param>
    /// <returns>A <see cref="TypeBinaryExpression"/> that represents the specified type checking.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="expression"/> or <paramref name="type"/> is null.</exception>
    public static TypeBinaryExpression Is(this Expression expression, Type type)
    {
        return Expression.TypeIs(expression, type);
    }

    /// <summary>
    /// Creates a <see cref="TypeBinaryExpression"/> that represents the specified type checking.
    /// </summary>
    /// <typeparam name="T">The type to check the <paramref name="expression"/></typeparam>
    /// <param name="expression">An <see cref="Expression"/> whose type to be checked.</param>
    /// <returns>A <see cref="TypeBinaryExpression"/> that represents the specified type checking.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="expression"/> is null.</exception>
    public static TypeBinaryExpression Is<T>(this Expression expression)
    {
        return Expression.TypeIs(expression, typeof(T));
    }
}