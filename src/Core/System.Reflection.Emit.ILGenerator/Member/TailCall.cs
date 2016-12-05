using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Performs a tail call to the given method, popping the requisite number of arguments from the evaluation stack
    ///     (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to call</param>
    public static ILGenerator TailCall(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        il.Emit(OpCodes.Tailcall);
        return il.Call(method);
    }

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T>(this ILGenerator il, Expression<Action<T>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall(this ILGenerator il, Expression<Action> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2>(this ILGenerator il, Expression<Action<T1, T2>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3>(this ILGenerator il, Expression<Action<T1, T2, T3>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4>(this ILGenerator il, Expression<Action<T1, T2, T3, T4>> expression)
        => il.TailCall(GetMethodInfo(expression));

#if !Net35
    
    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, T6>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, T6, T7>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6, T7>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, T6, T7, T8>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, T6, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, T6, T7, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));
#endif

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<TResult>(this ILGenerator il, Expression<Func<TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T, TResult>(this ILGenerator il, Expression<Func<T, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, TResult>(this ILGenerator il, Expression<Func<T1, T2, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression, popping the requisite number of arguments
    ///     from the evaluation stack (including the this reference if it is an instance method)
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCall<T1, T2, T3, T4, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, TResult>> expression)
        => il.TailCall(GetMethodInfo(expression));
}