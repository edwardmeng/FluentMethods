using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a MethodCallExpression that represents a call to a static method.
    /// </summary>
    /// <param name="method">The <see cref="MethodInfo"/> that represents the target method.</param>
    /// <param name="arguments">A collection of <see cref="Expression"/> that represents the call arguments.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to the static method.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="method"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// <paramref name="method"/> is not static.
    /// -or-
    /// The parameter numbers or types of <paramref name="arguments"/> does not matches <paramref name="method"/>.
    /// </exception>
    public static MethodCallExpression Call(this MethodInfo method, System.Collections.Generic.IEnumerable<Expression> arguments)
    {
#if Net35
        return Expression.Call(method, arguments.ToArray());
#else
        return Expression.Call(method, arguments);
#endif
    }

    /// <summary>
    /// Creates a MethodCallExpression that represents a call to a static method.
    /// </summary>
    /// <param name="method">The <see cref="MethodInfo"/> that represents the target method.</param>
    /// <param name="arguments">A collection of <see cref="Expression"/> that represents the call arguments.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to the static method.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="method"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// <paramref name="method"/> is not static.
    /// -or-
    /// The parameter numbers or types of <paramref name="arguments"/> does not matches <paramref name="method"/>.
    /// </exception>
    public static MethodCallExpression Call(this MethodInfo method, params Expression[] arguments)
    {
        return Expression.Call(method, arguments);
    }
}