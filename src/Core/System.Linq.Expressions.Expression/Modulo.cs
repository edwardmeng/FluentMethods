using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression Modulo(this Expression left, Expression right)
    {
        return Expression.Modulo(left, right);
    }
}