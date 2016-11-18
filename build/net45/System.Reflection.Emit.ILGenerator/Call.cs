using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Calls the given method, popping the requisite number of arguments from the evaluation stack (including the this
    ///     reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to call</param>
    public static ILGenerator Call(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        il.Emit(OpCodes.Call, method);
        return il;
    }

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T>(this ILGenerator il, Expression<Action<T>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call(this ILGenerator il, Expression<Action> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2>(this ILGenerator il, Expression<Action<T1, T2>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3>(this ILGenerator il, Expression<Action<T1, T2, T3>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4>(this ILGenerator il, Expression<Action<T1, T2, T3, T4>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, T6>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, T6, T7>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6, T7>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, T6, T7, T8>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<TResult>(this ILGenerator il, Expression<Func<TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T, TResult>(this ILGenerator il, Expression<Func<T, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, TResult>(this ILGenerator il, Expression<Func<T1, T2, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, T6, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, T6, T7, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    /// <summary>
    ///     Calls the method represented by the given expression, popping the requisite number of arguments from the evaluation
    ///     stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator Call<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expression)
        => il.Call(GetMethodInfo(expression));

    private static MethodInfo GetMethodInfo(LambdaExpression expression)
    {
        if (expression == null)
            throw new ArgumentNullException(nameof(expression));
        var method = (expression.Body as MethodCallExpression)?.Method;

        if (method == null)
            throw new InvalidOperationException("Expression does not represent a method call");

        return method;
    }
}