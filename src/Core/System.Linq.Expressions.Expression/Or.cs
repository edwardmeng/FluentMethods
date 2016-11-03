using System;
using System.Linq.Expressions;

public static partial class Extensions
{
#if !Net35
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        return first.Compose(second, Expression.OrElse);
    }
#endif
    public static BinaryExpression Or(this Expression left, Expression right)
    {
        return Expression.Or(left, right);
    }
}