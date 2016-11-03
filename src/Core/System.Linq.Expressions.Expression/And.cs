using System;
using System.Linq.Expressions;

public static partial class Extensions
{
#if !Net35
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        return first.Compose(second, Expression.AndAlso);
    }
#endif
    public static BinaryExpression And(this Expression left, Expression right)
    {
        return Expression.And(left, right);
    }

}