using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression Subtract(this Expression left, Expression right)
    {
        return Expression.Subtract(left, right);
    }
}