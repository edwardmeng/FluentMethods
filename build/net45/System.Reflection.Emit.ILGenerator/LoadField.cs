using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static FieldInfo GetFieldInfo<T, TField>(Expression<Func<T, TField>> expression)
    {
        if (expression == null)
            throw new ArgumentNullException(nameof(expression));
        var field = (expression.Body as MemberExpression)?.Member as FieldInfo;

        if (field == null)
            throw new ArgumentException("Expression does not represent a field", nameof(expression));

        return field;
    }

    private static FieldInfo GetFieldInfo<TField>(Expression<Func<TField>> expression)
    {
        if (expression == null)
            throw new ArgumentNullException(nameof(expression));
        var field = (expression.Body as MemberExpression)?.Member as FieldInfo;

        if (field == null)
            throw new ArgumentException("Expression does not represent a field", nameof(expression));

        return field;
    }

    private static FieldInfo GetFieldInfo(Type type, string fieldName)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        if (field == null)
            throw new InvalidOperationException("Field with name `" + fieldName + "` cannot be found on type " + type.Name);

        return field;
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load.</param>
    public static ILGenerator LoadField(this ILGenerator il, FieldInfo field)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        il.Emit(field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, field);
        return il;
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadField(this ILGenerator il, Type type, string fieldName)
        => il.LoadField(GetFieldInfo(type, fieldName));

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field (with the given name on the given
    ///     type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadField<T>(this ILGenerator il, string fieldName)
        => il.LoadField(typeof(T), fieldName);

    /// <summary>
    ///     Pushes the value of the static field represented by the given expression
    /// </summary>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadField<TField>(this ILGenerator il, Expression<Func<TField>> fieldExpression)
        => il.LoadField(GetFieldInfo(fieldExpression));

    /// <summary>
    ///     Pops a reference from the evaluation stack and pushes the value of the field represented by the given expression
    ///     for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadField<T, TField>(this ILGenerator il, Expression<Func<T, TField>> fieldExpression)
        => il.LoadField(GetFieldInfo(fieldExpression));
}