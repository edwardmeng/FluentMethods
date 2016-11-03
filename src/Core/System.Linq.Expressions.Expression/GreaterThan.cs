using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression GreaterThan(this Expression left, Expression right)
    {
        return Expression.GreaterThan(left, right);
    }
}