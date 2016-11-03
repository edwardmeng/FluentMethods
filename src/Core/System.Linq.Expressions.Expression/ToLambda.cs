using System.Collections.Generic;
using System.Linq.Expressions;

public static partial class Extensions
{
    public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body, IEnumerable<ParameterExpression> parameters)
    {
        return Expression.Lambda<TDelegate>(body, parameters);
    }
    public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body, params ParameterExpression[] parameters)
    {
        return Expression.Lambda<TDelegate>(body, parameters);
    }

    public static Expression ToLambda(this Expression body, params ParameterExpression[] parameters)
    {
        return Expression.Lambda(body, parameters);
    }

#if !Net35
    public static Expression ToLambda(this Expression body, IEnumerable<ParameterExpression> parameters)
    {
        return Expression.Lambda(body, parameters);
    }
#endif
}