using System;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a static method by calling the appropriate factory method.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> that specifies the type that contains the specified static method.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="typeArguments">
    /// An array of <see cref="Type"/> objects that specify the type parameters of the generic method. 
    /// This argument should be null when methodName specifies a non-generic method.
    /// </param>
    /// <param name="arguments">An array of <see cref="Expression"/> objects that represent the arguments to the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a static method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The method whose name is <paramref name="methodName"/> is not static.</exception>
    /// <exception cref="InvalidOperationException">
    /// No method whose name is <paramref name="methodName"/>, whose type parameters match <paramref name="typeArguments"/>, and whose parameter types match <paramref name="arguments"/> is found in <paramref name="type"/> or its base types.
    /// -or-
    /// More than one method whose name is <paramref name="methodName"/>, whose type parameters match <paramref name="typeArguments"/>, and whose parameter types match <paramref name="arguments"/> is found in <paramref name="type"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Type type, string methodName, Type[] typeArguments, params Expression[] arguments)
    {
        return Expression.Call(type, methodName, typeArguments, arguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a static method by calling the appropriate factory method.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> that specifies the type that contains the specified static method.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="typeArguments">
    /// An array of <see cref="Type"/> objects that specify the type parameters of the generic method. 
    /// This argument should be null when methodName specifies a non-generic method.
    /// </param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a static method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The method whose name is <paramref name="methodName"/> is not static.</exception>
    /// <exception cref="InvalidOperationException">
    /// No method whose name is <paramref name="methodName"/> and whose type parameters match <paramref name="typeArguments"/> is found in <paramref name="type"/> or its base types.
    /// -or-
    /// More than one method whose name is <paramref name="methodName"/> and whose type parameters match <paramref name="typeArguments"/> is found in <paramref name="type"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Type type, string methodName, params Type[] typeArguments)
    {
        return Expression.Call(type, methodName, typeArguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a static method by calling the appropriate factory method.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> that specifies the type that contains the specified static method.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="arguments">An array of <see cref="Expression"/> objects that represent the arguments to the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a static method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The method whose name is <paramref name="methodName"/> is not static.</exception>
    /// <exception cref="InvalidOperationException">
    /// No method whose name is <paramref name="methodName"/>, and whose parameter types match <paramref name="arguments"/> is found in <paramref name="type"/> or its base types.
    /// -or-
    /// More than one method whose name is <paramref name="methodName"/>, and whose parameter types match <paramref name="arguments"/> is found in <paramref name="type"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Type type, string methodName, params Expression[] arguments)
    {
        return Expression.Call(type, methodName, null, arguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a non-generic static method by calling the appropriate factory method.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> that specifies the type that contains the specified non-generic static method.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a non-generic static method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The method whose name is <paramref name="methodName"/> is not static.</exception>
    /// <exception cref="InvalidOperationException">
    /// No non-generic method whose name is <paramref name="methodName"/> is found in <paramref name="type"/> or its base types.
    /// -or-
    /// More than one non-generic method whose name is <paramref name="methodName"/> is found in <paramref name="type"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Type type, string methodName)
    {
        return Expression.Call(type, methodName, null);
    }
}