using System.Linq.Expressions;

public static partial class Extensions
{
    public static BinaryExpression Add(this Expression left, Expression right)
    {
        return Expression.Add(left, right);
    }
}