using System;
using System.Linq.Expressions;

public static partial class Extensions
{
    public static MethodCallExpression Call(this Type type, string methodName, Type[] typeArguments, params Expression[] arguments)
    {
        return Expression.Call(type, methodName, typeArguments, arguments);
    }

    public static MethodCallExpression Call(this Type type, string methodName, params Expression[] arguments)
    {
        return Expression.Call(type, methodName, new Type[0], arguments);
    }
}