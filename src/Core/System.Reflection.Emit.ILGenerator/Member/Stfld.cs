﻿using FluentMethods;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator Stfld<T>(this ILGenerator il, FieldInfo field, T value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(T))
            throw new InvalidOperationException(string.Format(Strings.FieldTypeNotMatch, field.Name, field.DeclaringType?.FullName, typeof(T).FullName));

        return il.Ldc(value).Stfld(field);
    }

    private static ILGenerator Stfld<T>(this ILGenerator il, Type type, string fieldName, T value)
        => il.Stfld(GetFieldInfo(type, fieldName), value);

    private static ILGenerator Stfld<T, TValue>(this ILGenerator il, string fieldName, TValue value)
        => il.Stfld(typeof(T), fieldName, value);

    private static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T>> fieldExpression, T value)
        => il.Stfld(GetFieldInfo(fieldExpression), value);

    private static ILGenerator Stfld<T, TValue>(this ILGenerator il, Expression<Func<T, TValue>> fieldExpression, TValue value)
        => il.Stfld(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.IsInitOnly || field.IsLiteral)
            throw new InvalidOperationException(string.Format(Strings.CannotWriteField, field.Name, field.DeclaringType?.FullName));
        return il.FluentEmit(field.IsStatic ? OpCodes.Stsfld : OpCodes.Stfld, field);
    }

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field (with the given name on
    ///     the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName)
        => il.Stfld(GetFieldInfo(type, fieldName));

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field (with the given name on
    ///     the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName)
        => il.Stfld(typeof(T), fieldName);

    /// <summary>
    ///     Pops a value from the evaluation stack and stores the value in the static field represented by the given expression
    /// </summary>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator Stfld<TField>(this ILGenerator il, Expression<Func<TField>> fieldExpression)
        => il.Stfld(GetFieldInfo(fieldExpression));

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator Stfld<T, TField>(this ILGenerator il, Expression<Func<T, TField>> fieldExpression)
        => il.Stfld(GetFieldInfo(fieldExpression));

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Boolean" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, bool value)
        => il.Stfld<bool>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Boolean" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, bool value)
        => il.Stfld<bool>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Boolean" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, bool value)
        => il.Stfld<T, bool>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<bool>> fieldExpression, bool value)
        => il.Stfld<bool>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, bool>> fieldExpression, bool value)
        => il.Stfld<T, bool>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Char" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, char value)
        => il.Stfld<char>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Char" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, char value)
        => il.Stfld<char>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Char" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, char value)
        => il.Stfld<T, char>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<char>> fieldExpression, char value)
        => il.Stfld<char>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, char>> fieldExpression, char value)
        => il.Stfld<T, char>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="SByte" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, sbyte value)
        => il.Stfld<sbyte>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="SByte" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, sbyte value)
        => il.Stfld<sbyte>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="SByte" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, sbyte value)
        => il.Stfld<T, sbyte>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<sbyte>> fieldExpression, sbyte value)
        => il.Stfld<sbyte>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, sbyte>> fieldExpression, sbyte value)
        => il.Stfld<T, sbyte>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Byte" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, byte value)
        => il.Stfld<byte>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Byte" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, byte value)
        => il.Stfld<byte>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Byte" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, byte value)
        => il.Stfld<T, byte>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<byte>> fieldExpression, byte value)
        => il.Stfld<byte>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, byte>> fieldExpression, byte value)
        => il.Stfld<T, byte>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, short value)
        => il.Stfld<short>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, short value)
        => il.Stfld<short>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, short value)
        => il.Stfld<T, short>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<short>> fieldExpression, short value)
        => il.Stfld<short>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, short>> fieldExpression, short value)
        => il.Stfld<T, short>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, ushort value)
        => il.Stfld<ushort>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, ushort value)
        => il.Stfld<ushort>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, ushort value)
        => il.Stfld<T, ushort>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<ushort>> fieldExpression, ushort value)
        => il.Stfld<ushort>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, ushort>> fieldExpression, ushort value)
        => il.Stfld<T, ushort>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, int value)
        => il.Stfld<int>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, int value)
        => il.Stfld<int>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, int value)
        => il.Stfld<T, int>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<int>> fieldExpression, int value)
        => il.Stfld<int>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, int>> fieldExpression, int value)
        => il.Stfld<T, int>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, uint value)
        => il.Stfld<uint>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, uint value)
        => il.Stfld<uint>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, uint value)
        => il.Stfld<T, uint>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<uint>> fieldExpression, uint value)
        => il.Stfld<uint>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, uint>> fieldExpression, uint value)
        => il.Stfld<T, uint>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, long value)
        => il.Stfld<long>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, long value)
        => il.Stfld<long>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, long value)
        => il.Stfld<T, long>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<long>> fieldExpression, long value)
        => il.Stfld<long>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, long>> fieldExpression, long value)
        => il.Stfld<T, long>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, ulong value)
        => il.Stfld<ulong>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, ulong value)
        => il.Stfld<ulong>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, ulong value)
        => il.Stfld<T, ulong>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<ulong>> fieldExpression, ulong value)
        => il.Stfld<ulong>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, ulong>> fieldExpression, ulong value)
        => il.Stfld<T, ulong>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, float value)
        => il.Stfld<float>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, float value)
        => il.Stfld<float>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, float value)
        => il.Stfld<T, float>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<float>> fieldExpression, float value)
        => il.Stfld<float>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, float>> fieldExpression, float value)
        => il.Stfld<T, float>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, double value)
        => il.Stfld<double>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, double value)
        => il.Stfld<double>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, double value)
        => il.Stfld<T, double>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<double>> fieldExpression, double value)
        => il.Stfld<double>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, double>> fieldExpression, double value)
        => il.Stfld<T, double>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="decimal" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, decimal value)
        => il.Stfld<decimal>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="decimal" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, decimal value)
        => il.Stfld<decimal>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="decimal" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, decimal value)
        => il.Stfld<T, decimal>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<decimal>> fieldExpression, decimal value)
        => il.Stfld<decimal>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, decimal>> fieldExpression, decimal value)
        => il.Stfld<T, decimal>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="string" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, FieldInfo field, string value)
        => il.Stfld<string>(field, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="string" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, Type type, string fieldName, string value)
        => il.Stfld<string>(type, fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="string" /></exception>
    public static ILGenerator Stfld<T>(this ILGenerator il, string fieldName, string value)
        => il.Stfld<T, string>(fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld(this ILGenerator il, Expression<Func<string>> fieldExpression, string value)
        => il.Stfld<string>(fieldExpression, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator Stfld<T>(this ILGenerator il, Expression<Func<T, string>> fieldExpression, string value)
        => il.Stfld<T, string>(fieldExpression, value);

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field (with the given name on
    ///     the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName)
        => il.Stfld(type?.AsType(), fieldName);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="bool" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, bool value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="char" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, char value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="byte" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, byte value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="sbyte" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, sbyte value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="short" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, short value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="ushort" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, ushort value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="int" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, int value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="uint" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, uint value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="long" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, long value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="ulong" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, ulong value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="float" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, float value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="double" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, double value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="decimal" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, decimal value)
        => il.Stfld(type?.AsType(), fieldName, value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="string" /></exception>
    public static ILGenerator Stfld(this ILGenerator il, TypeInfo type, string fieldName, string value)
        => il.Stfld(type?.AsType(), fieldName, value);
#endif
}