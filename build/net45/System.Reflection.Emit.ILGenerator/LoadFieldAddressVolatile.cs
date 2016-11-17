using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops a reference from the evaluation stack and pushes the address of the given field for that object, with volatile semantics
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load</param>
    public static ILGenerator LoadFieldAddressVolatile(this ILGenerator il, FieldInfo field)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (field == null)
        {
            throw new ArgumentNullException(nameof(field));
        }
        il.Emit(OpCodes.Volatile);
        return il.LoadFieldAddress(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and pushes the address of the field (with the given name on the given type) for that object, with volatile semantics
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadFieldAddressVolatile(this ILGenerator il, Type type, string fieldName)
        => il.LoadFieldAddressVolatile(GetFieldInfo(type, fieldName));

    /// <summary>
    /// Pops a reference from the evaluation stack and pushes the address of the field (with the given name on the given type) for that object, with volatile semantics
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator LoadFieldAddressVolatile<T>(this ILGenerator il, string fieldName)
        => il.LoadFieldAddressVolatile(typeof(T), fieldName);

    /// <summary>
    /// Pushes the address of the static field represented by the given expression, with volatile semantics
    /// </summary>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadFieldAddressVolatile<TField>(this ILGenerator il, Expression<Func<TField>> fieldExpression)
        => il.LoadFieldAddressVolatile(GetFieldInfo(fieldExpression));

    /// <summary>
    /// Pops a reference from the evaluation stack and pushes the address of the field represented by the given expression for that object, with volatile semantics
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator LoadFieldAddressVolatile<T, TField>(this ILGenerator il, Expression<Func<T, TField>> fieldExpression)
        => il.LoadFieldAddressVolatile(GetFieldInfo(fieldExpression));
}