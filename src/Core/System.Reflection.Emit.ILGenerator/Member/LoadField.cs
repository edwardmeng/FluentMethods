using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load.</param>
    public static ILGenerator LoadField(this ILGenerator il, FieldInfo field) => il.Ldfld(field);

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadField(this ILGenerator il, Type type, string fieldName) => il.Ldfld(type, fieldName);

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadField(this ILGenerator il, TypeInfo type, string fieldName) => il.Ldfld(type, fieldName);
#endif

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadField<T>(this ILGenerator il, string fieldName) => il.Ldfld<T>(fieldName);

    /// <summary>
    ///     Pushes the value of the static field represented by the given expression
    /// </summary>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadField<TField>(this ILGenerator il, Expression<Func<TField>> fieldExpression) => il.Ldfld(fieldExpression);

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field represented by the given expression
    ///     for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadField<T, TField>(this ILGenerator il, Expression<Func<T, TField>> fieldExpression) => il.Ldfld(fieldExpression);
}