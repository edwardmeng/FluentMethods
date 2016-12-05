using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Performs a constrained virtual tail call to the given method, popping an address to storage location of the value
    ///     or reference (and performing a null check if necessary) and the requisite number of arguments from the evaluation
    ///     stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="method">The method to call</param>
    public static ILGenerator ConstrainedTailCall(this ILGenerator il, Type constrainedType, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        il.Emit(OpCodes.Constrained, constrainedType);
        il.Emit(OpCodes.Tailcall);
        il.Emit(OpCodes.Callvirt, method);
        return il;
    }

    /// <summary>
    ///     Performs a constrained virtual tail call to the given method, popping an address to storage location of the value
    ///     or reference (and performing a null check if necessary) and the requisite number of arguments from the evaluation
    ///     stack
    /// </summary>
    /// <typeparam name="T">The type to constrain the call to</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to call</param>
    public static ILGenerator ConstrainedTailCall<T>(this ILGenerator il, MethodInfo method)
        => il.ConstrainedTailCall(typeof(T), method);

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T>(this ILGenerator il, Type constrainedType, Expression<Action<T>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall(this ILGenerator il, Type constrainedType, Expression<Action> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2, T3>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2, T3, T4>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

#if !Net35
    
    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2, T3, T4, T5>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, T6>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2, T3, T4, T5, T6>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, T6, T7>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2, T3, T4, T5, T6, T7>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, T6, T7, T8>(this ILGenerator il, Type constrainedType, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, T3, T4, T5, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, T6, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, T6, T7, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));
    
#endif

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<TResult>(this ILGenerator il, Type constrainedType, Expression<Func<TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, T3, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));

    /// <summary>
    ///     Performs a constrained virtual tail call to the method represented by the given expression, popping an address to
    ///     storage location of the value or reference (and performing a null check if necessary) and the requisite number of
    ///     arguments from the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constrainedType">The type to constrain the call to</param>
    /// <param name="expression">The expression representing the method to call</param>
    public static ILGenerator ConstrainedTailCall<T1, T2, T3, T4, TResult>(this ILGenerator il, Type constrainedType, Expression<Func<T1, T2, T3, T4, TResult>> expression)
        => il.ConstrainedTailCall(constrainedType, GetMethodInfo(expression));
}