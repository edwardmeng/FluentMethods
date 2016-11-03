using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
#if !Net35
    public static MethodCallExpression Call(this MethodInfo method, System.Collections.Generic.IEnumerable<Expression> arguments)
    {
        return Expression.Call(method, arguments);
    }
#endif
    public static MethodCallExpression Call(this MethodInfo method, params Expression[] arguments)
    {
        return Expression.Call(method, arguments);
    }
}