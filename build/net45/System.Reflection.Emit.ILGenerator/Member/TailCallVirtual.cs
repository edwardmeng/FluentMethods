﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Performs a tail call to the given method with virtual semantics, popping a reference (and performing a null check)
    ///     and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to call</param>
    public static ILGenerator TailCallVirtual(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        il.Emit(OpCodes.Tailcall);
        il.Emit(OpCodes.Callvirt, method);
        return il;
    }

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T>(this ILGenerator il, Expression<Action<T>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual(this ILGenerator il, Expression<Action> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2>(this ILGenerator il, Expression<Action<T1, T2>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3>(this ILGenerator il, Expression<Action<T1, T2, T3>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4>(this ILGenerator il, Expression<Action<T1, T2, T3, T4>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, T6>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, T6, T7>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6, T7>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, T6, T7, T8>(this ILGenerator il, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<TResult>(this ILGenerator il, Expression<Func<TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T, TResult>(this ILGenerator il, Expression<Func<T, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, TResult>(this ILGenerator il, Expression<Func<T1, T2, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, T6, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, T6, T7, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));

    /// <summary>
    ///     Performs a tail call to the method represented by the given expression with virtual semantics, popping a reference
    ///     (and performing a null check) and the requisite number of arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator TailCallVirtual<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this ILGenerator il, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expression)
        => il.TailCallVirtual(GetMethodInfo(expression));
}