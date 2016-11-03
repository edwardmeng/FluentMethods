using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression LessThan(this Expression left, Expression right)
    {
        return Expression.LessThan(left, right);
    }
}