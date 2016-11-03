using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression Divide(this Expression left, Expression right)
    {
        return Expression.Divide(left, right);
    }
}