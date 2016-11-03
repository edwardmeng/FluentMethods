using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression Power(this Expression left, Expression right)
    {
        return Expression.Power(left, right);
    }
}