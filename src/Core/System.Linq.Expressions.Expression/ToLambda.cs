using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates an <see cref="Expression{T}"/> where the delegate type is known at compile time.
    /// </summary>
    /// <typeparam name="TDelegate">A delegate type.</typeparam>
    /// <param name="body">The body of lambda expression.</param>
    /// <param name="parameters">An <see cref="IEnumerable{ParameterExpression}"/> that represents the parameters of the lambda expression.</param>
    /// <returns>An <see cref="Expression{T}"/> where the delegate type is known at compile time.</returns>
    public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body, IEnumerable<ParameterExpression> parameters)
    {
        return Expression.Lambda<TDelegate>(body, parameters);
    }

    /// <summary>
    /// Creates an <see cref="Expression{T}"/> where the delegate type is known at compile time.
    /// </summary>
    /// <typeparam name="TDelegate">A delegate type.</typeparam>
    /// <param name="body">The body of lambda expression.</param>
    /// <param name="parameters">An <see cref="IEnumerable{ParameterExpression}"/> that represents the parameters of the lambda expression.</param>
    /// <returns>An <see cref="Expression{T}"/> where the delegate type is known at compile time.</returns>
    public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body, params ParameterExpression[] parameters)
    {
        return Expression.Lambda<TDelegate>(body, parameters);
    }

    /// <summary>
    /// Creates a <see cref="LambdaExpression"/> by first constructing a delegate type.
    /// </summary>
    /// <param name="body">The body of lambda expression.</param>
    /// <param name="parameters">An <see cref="IEnumerable{ParameterExpression}"/> that represents the parameters of the lambda expression.</param>
    /// <returns>A <see cref="LambdaExpression"/> by first constructing a delegate type.</returns>
    public static LambdaExpression ToLambda(this Expression body, params ParameterExpression[] parameters)
    {
        return Expression.Lambda(body, parameters);
    }

    /// <summary>
    /// Creates a <see cref="LambdaExpression"/> by first constructing a delegate type.
    /// </summary>
    /// <param name="body">The body of lambda expression.</param>
    /// <param name="parameters">An <see cref="IEnumerable{ParameterExpression}"/> that represents the parameters of the lambda expression.</param>
    /// <returns>A <see cref="LambdaExpression"/> by first constructing a delegate type.</returns>
    public static LambdaExpression ToLambda(this Expression body, IEnumerable<ParameterExpression> parameters)
    {
#if Net35
        return Expression.Lambda(body, parameters.ToArray());
#else
        return Expression.Lambda(body, parameters);
#endif
    }
}