using System;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents a type conversion operation.
    /// </summary>
    /// <param name="expression">The <see cref="Expression"/> to perform the type conversion operation.</param>
    /// <param name="type">The <see cref="Type"/> to convert the expression to.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents a type conversion operation of the <paramref name="expression"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="expression"/> or <paramref name="type"/> is null.</exception>
    /// <exception cref="InvalidOperationException">No conversion operator is defined between the type of <paramref name="expression"/> and <paramref name="type"/>.</exception>
    public static UnaryExpression To(this Expression expression, Type type)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
#if !Net35
        if ((expression.Type.IsInterface || expression.Type == typeof(object)) && type.IsValueType && !type.IsGenericTypeDefinition && !type.ContainsGenericParameters)
        {
            return Expression.Unbox(expression, type);
        }
#endif
        if ((!type.IsValueType || type.IsNullable()) && !type.IsGenericTypeDefinition && !type.ContainsGenericParameters)
        {
            return Expression.TypeAs(expression, type);
        }
        return Expression.Convert(expression, type);
    }

    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that represents a type conversion operation.
    /// </summary>
    /// <typeparam name="T">The type to convert the expression to.</typeparam>
    /// <param name="expression">The <see cref="Expression"/> to perform the type conversion operation.</param>
    /// <returns>A <see cref="UnaryExpression"/> that represents a type conversion operation of the <paramref name="expression"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="expression"/> is null.</exception>
    /// <exception cref="InvalidOperationException">No conversion operator is defined between the type of <paramref name="expression"/> and <typeparamref name="T"/>.</exception>
    public static UnaryExpression To<T>(this Expression expression)
    {
        return expression.To(typeof(T));
    }
}