using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a method that takes no arguments.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance method call.</param>
    /// <param name="method">A <see cref="MethodInfo"/> to be called.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a method that takes no arguments.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="instance"/> or <paramref name="method"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The type of <paramref name="instance"/> is not assignable to the declaring type of the method represented by method.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, MethodInfo method)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, method);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a method that takes arguments.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance method call.</param>
    /// <param name="method">A <see cref="MethodInfo"/> to be called.</param>
    /// <param name="arguments">An <see cref="IEnumerable{Expression}"/> that contains expressions to use to call the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a method that takes arguments.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="instance"/> or <paramref name="method"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The type of <paramref name="instance"/> is not assignable to the declaring type of the method represented by method.
    /// -or-
    /// The number of elements in arguments does not equal the number of parameters for the method represented by <paramref name="method"/>.
    /// -or-
    /// One or more of the elements of arguments is not assignable to the corresponding parameter for the method represented by <paramref name="method"/>.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, MethodInfo method, IEnumerable<Expression> arguments)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, method, arguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a method that takes arguments.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance method call.</param>
    /// <param name="method">A <see cref="MethodInfo"/> to be called.</param>
    /// <param name="arguments">An array of <see cref="Expression"/> to use to call the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a method that takes arguments.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="instance"/> or <paramref name="method"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The type of <paramref name="instance"/> is not assignable to the declaring type of the method represented by method.
    /// -or-
    /// The number of elements in arguments does not equal the number of parameters for the method represented by <paramref name="method"/>.
    /// -or-
    /// One or more of the elements of arguments is not assignable to the corresponding parameter for the method represented by <paramref name="method"/>.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, MethodInfo method, params Expression[] arguments)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, method, arguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a non-generic instance method by calling the appropriate factory method.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for a non-generic instance method call.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a non-generic instance method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// No non-generic instance method whose name is <paramref name="methodName"/> is found in the type of <paramref name="instance"/> or its base types.
    /// -or-
    /// More than one non-generic instance method whose name is <paramref name="methodName"/> is found in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, string methodName)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, methodName, null);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a generic method by calling the appropriate factory method.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance method call.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="typeArguments">
    /// An array of <see cref="Type"/> objects that specify the type parameters of the generic method. 
    /// This argument should be null when methodName specifies a non-generic method.
    /// </param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// No method whose name is <paramref name="methodName"/> and whose type parameters match <paramref name="typeArguments"/> is found in the type of <paramref name="instance"/> or its base types.
    /// -or-
    /// More than one method whose name is <paramref name="methodName"/> and whose type parameters match <paramref name="typeArguments"/> is found in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, string methodName, params Type[] typeArguments)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, methodName, typeArguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a method by calling the appropriate factory method.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance method call.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="typeArguments">
    /// An array of <see cref="Type"/> objects that specify the type parameters of the generic method. 
    /// This argument should be null when methodName specifies a non-generic method.
    /// </param>
    /// <param name="arguments">An array of <see cref="Expression"/> to use to call the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// No method whose name is <paramref name="methodName"/>, whose type parameters match <paramref name="typeArguments"/>, and whose parameter types match <paramref name="arguments"/> is found in the type of <paramref name="instance"/> or its base types.
    /// -or-
    /// More than one method whose name is <paramref name="methodName"/>, whose type parameters match <paramref name="typeArguments"/>, and whose parameter types match <paramref name="arguments"/> is found in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, string methodName, Type[] typeArguments, params Expression[] arguments)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, methodName, typeArguments, arguments);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents a call to a non-generic method by calling the appropriate factory method.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance method call.</param>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="arguments">An array of <see cref="Expression"/> to use to call the method.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents a call to a method by calling the appropriate factory method.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="methodName"/> is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// No non-generic method whose name is <paramref name="methodName"/>, and whose parameter types match <paramref name="arguments"/> is found in the type of <paramref name="instance"/> or its base types.
    /// -or-
    /// More than one non-generic method whose name is <paramref name="methodName"/>, and whose parameter types match <paramref name="arguments"/> is found in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MethodCallExpression Call(this Expression instance, string methodName, params Expression[] arguments)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Call(instance, methodName, null, arguments);
    }

}