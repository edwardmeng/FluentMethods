using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the address of the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load</param>
    public static ILGenerator LoadFieldAddress(this ILGenerator il, FieldInfo field) => il.Ldflda(field);

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the address of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadFieldAddress(this ILGenerator il, Type type, string fieldName)
        => il.Ldflda(type, fieldName);

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the address of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadFieldAddress(this ILGenerator il, TypeInfo type, string fieldName)
        => il.Ldflda(type, fieldName);
#endif

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the address of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadFieldAddress<T>(this ILGenerator il, string fieldName)
        => il.Ldflda<T>(fieldName);

    /// <summary>
    ///     Pushes the address of the static field represented by the given expression
    /// </summary>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadFieldAddress<TField>(this ILGenerator il, Expression<Func<TField>> fieldExpression)
        => il.Ldflda(fieldExpression);

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the address of the field represented by the given expression
    ///     for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadFieldAddress<T, TField>(this ILGenerator il, Expression<Func<T, TField>> fieldExpression)
        => il.Ldflda(fieldExpression);
}