using System.Linq.Expressions;

public static partial class Extensions
{
    public static UnaryExpression Negate(this Expression expression)
    {
        return Expression.Negate(expression);
    }
}