using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression LessThanOrEqual(this Expression left, Expression right)
    {
        return Expression.LessThanOrEqual(left, right);
    }
}