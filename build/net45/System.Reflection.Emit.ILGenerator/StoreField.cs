using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if(field.IsInitOnly || field.IsLiteral)
            throw new InvalidOperationException("Cannot write to this field.");
        il.Emit(field.IsStatic ? OpCodes.Stsfld : OpCodes.Stfld, field);
        return il;
    }

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field (with the given name on
    ///     the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName)
        => il.StoreField(GetFieldInfo(type, fieldName));

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field (with the given name on
    ///     the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName)
        => il.StoreField(typeof(T), fieldName);

    /// <summary>
    ///     Pops a value from the evaluation stack and stores the value in the static field represented by the given expression
    /// </summary>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator StoreField<TField>(this ILGenerator il, Expression<Func<TField>> fieldExpression)
        => il.StoreField(GetFieldInfo(fieldExpression));

    /// <summary>
    ///     Pops a reference and a value from the evaluation stack and stores the value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <typeparam name="TField">The type of the field</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    public static ILGenerator StoreField<T, TField>(this ILGenerator il, Expression<Func<T, TField>> fieldExpression)
        => il.StoreField(GetFieldInfo(fieldExpression));

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Boolean" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, bool value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(bool))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Boolean" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, bool value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Boolean" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, bool value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<bool>> fieldExpression, bool value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, bool>> fieldExpression, bool value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Char" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, char value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(char))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Char" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, char value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Char" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, char value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<char>> fieldExpression, char value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, char>> fieldExpression, char value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="SByte" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, sbyte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(sbyte))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="SByte" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, sbyte value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="SByte" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, sbyte value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<sbyte>> fieldExpression, sbyte value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, sbyte>> fieldExpression, sbyte value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Byte" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, byte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(byte))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Byte" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, byte value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Byte" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, byte value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<byte>> fieldExpression, byte value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, byte>> fieldExpression, byte value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, short value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(short))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, short value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, short value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<short>> fieldExpression, short value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, short>> fieldExpression, short value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, ushort value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(ushort))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, ushort value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, ushort value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<ushort>> fieldExpression, ushort value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, ushort>> fieldExpression, ushort value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, int value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(int))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, int value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, int value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<int>> fieldExpression, int value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, int>> fieldExpression, int value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, uint value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(uint))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, uint value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, uint value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<uint>> fieldExpression, uint value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, uint>> fieldExpression, uint value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, long value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(long))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, long value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, long value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<long>> fieldExpression, long value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, long>> fieldExpression, long value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, ulong value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(ulong))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, ulong value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, ulong value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<ulong>> fieldExpression, ulong value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, ulong>> fieldExpression, ulong value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, float value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(float))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, float value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, float value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<float>> fieldExpression, float value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, float>> fieldExpression, float value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, double value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(double))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, double value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, double value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<double>> fieldExpression, double value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, double>> fieldExpression, double value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, string value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        if (field.FieldType != typeof(string))
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, string value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the
    ///     given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, string value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    ///     Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<string>> fieldExpression, string value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    ///     Pops a reference from the evaluation stack and stores the given value in the field represented by the given
    ///     expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, string>> fieldExpression, string value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);
}