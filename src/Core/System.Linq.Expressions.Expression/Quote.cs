using System.Linq.Expressions;

public static partial class Extensions
{
    public static UnaryExpression Quote(this Expression expression)
    {
        return Expression.Quote(expression);
    }
}