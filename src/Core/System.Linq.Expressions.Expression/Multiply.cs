using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression Multiply(this Expression left, Expression right)
    {
        return Expression.Multiply(left, right);
    }
}