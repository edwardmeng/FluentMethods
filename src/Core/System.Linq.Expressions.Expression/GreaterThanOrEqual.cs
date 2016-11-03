using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression GreaterThanOrEqual(this Expression left, Expression right)
    {
        return Expression.GreaterThanOrEqual(left, right);
    }
}