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
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, Int16 value)
    {
        if (field.FieldType != typeof(Int16))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value)
                        .StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, Int16 value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int16" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, Int16 value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<Int16>> fieldExpression, Int16 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, Int16>> fieldExpression, Int16 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, UInt16 value)
    {
        if (field.FieldType != typeof(UInt16))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, UInt16 value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt16" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, UInt16 value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<UInt16>> fieldExpression, UInt16 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, UInt16>> fieldExpression, UInt16 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, Int32 value)
    {
        if (field.FieldType != typeof(Int32))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, Int32 value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int32" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, Int32 value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<Int32>> fieldExpression, Int32 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, Int32>> fieldExpression, Int32 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, UInt32 value)
    {
        if (field.FieldType != typeof(UInt32))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, UInt32 value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt32" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, UInt32 value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<UInt32>> fieldExpression, UInt32 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, UInt32>> fieldExpression, UInt32 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, Int64 value)
    {
        if (field.FieldType != typeof(Int64))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, Int64 value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Int64" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, Int64 value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<Int64>> fieldExpression, Int64 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, Int64>> fieldExpression, Int64 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, UInt64 value)
    {
        if (field.FieldType != typeof(UInt64))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, UInt64 value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="UInt64" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, UInt64 value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<UInt64>> fieldExpression, UInt64 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, UInt64>> fieldExpression, UInt64 value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, Single value)
    {
        if (field.FieldType != typeof(Single))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, Single value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Single" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, Single value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<Single>> fieldExpression, Single value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, Single>> fieldExpression, Single value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the given field for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to store the value in</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, FieldInfo field, Double value)
    {
        if (field.FieldType != typeof(Double))
        {
            throw new InvalidOperationException("Type mismatch - field is of type " + field.FieldType);
        }

        return il.LoadConst(value).StoreField(field);
    }

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type the field is on</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField(this ILGenerator il, Type type, string fieldName, Double value)
        => il.StoreField(GetFieldInfo(type, fieldName), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field (with the given name on the given type) for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldName">The name of the field</param>
    /// <param name="value">The value to overwrite the field with</param>
    /// <exception cref="InvalidOperationException">Thrown if the field is not of type <see cref="Double" /></exception>
    public static ILGenerator StoreField<T>(this ILGenerator il, string fieldName, Double value)
        => il.StoreField(typeof(T), fieldName, value);

    /// <summary>
    /// Stores the given value in the static field represented by the given expression
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField(this ILGenerator il, Expression<Func<Double>> fieldExpression, Double value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);

    /// <summary>
    /// Pops a reference from the evaluation stack and stores the given value in the field represented by the given expression for that object
    /// </summary>
    /// <typeparam name="T">The type the field is on</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="fieldExpression">An expression representing the field to load</param>
    /// <param name="value">The value to overwrite the field with</param>
    public static ILGenerator StoreField<T>(this ILGenerator il, Expression<Func<T, Double>> fieldExpression, Double value)
        => il.StoreField(GetFieldInfo(fieldExpression), value);
}