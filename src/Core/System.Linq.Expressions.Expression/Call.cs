using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    public static MethodCallExpression Call(this Expression instance, MethodInfo method)
    {
        return Expression.Call(instance, method);
    }
    public static MethodCallExpression Call(this Expression instance, MethodInfo method, IEnumerable<Expression> arguments)
    {
        return Expression.Call(instance, method, arguments);
    }
    public static MethodCallExpression Call(this Expression instance, MethodInfo method, params Expression[] arguments)
    {
        return Expression.Call(instance, method, arguments);
    }

    public static MethodCallExpression Call(this Expression instance, string methodName, Type[] typeArguments, params Expression[] arguments)
    {
        return Expression.Call(instance, methodName, typeArguments, arguments);
    }

    public static MethodCallExpression Call(this Expression instance, string methodName, params Expression[] arguments)
    {
        return Expression.Call(instance, methodName, new Type[0], arguments);
    }

}