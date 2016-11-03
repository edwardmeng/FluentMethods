using System.Linq.Expressions;

public static partial class Extensions
{
    public static UnaryExpression Not(this Expression expression)
    {
        return Expression.Not(expression);
    }
}