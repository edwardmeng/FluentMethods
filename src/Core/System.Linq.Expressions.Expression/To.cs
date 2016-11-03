using System;
using System.Linq.Expressions;

public static partial class Extensions
{
    public static UnaryExpression To(this Expression expression, Type type)
    {
#if !Net35
        if ((expression.Type.IsInterface || expression.Type == typeof(object)) && type.IsValueType && !type.IsGenericTypeDefinition && !type.ContainsGenericParameters)
        {
            return Expression.Unbox(expression, type);
        }
#endif
        if ((!type.IsValueType||type.IsNullable()) && !type.IsGenericTypeDefinition && !type.ContainsGenericParameters)
        {
            return Expression.TypeAs(expression, type);
        }
        return Expression.Convert(expression, type);
    }

    public static UnaryExpression To<T>(this Expression expression)
    {
        return expression.To(typeof(T));
    }
}