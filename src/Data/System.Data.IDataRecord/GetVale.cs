using System;
using System.Data;
using System.Data.SqlTypes;
using FluentMethods.Data;

public static partial class Extensions
{
    /// <summary>
    /// Return the value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/> to act on.</param>
    /// <param name="fieldName">The name of the field to find.</param>
    /// <returns>The field value.</returns>
    public static T GetValue<T>(this IDataRecord record, string fieldName)
    {
        if (record == null)
        {
            throw new ArgumentNullException(nameof(record));
        }
        var ordinal = record.GetOrdinal(fieldName);
        if (ordinal == -1)
        {
            throw new ArgumentException(string.Format(Strings.FieldCannotBeFound, fieldName));
        }
        if (record.IsDBNull(ordinal))
        {
            if (!typeof(T).IsValueType || (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                return default(T);
            }
            else
            {
                throw new InvalidOperationException(string.Format(Strings.CannotCastNullToValueType, fieldName, typeof(T)));
            }
        }
        if (typeof(T) == typeof(string))
        {
            return (T)(object)record.GetString(ordinal);
        }
        if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
        {
            return (T)(object)record.GetGuid(ordinal);
        }
        if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
        {
            return (T)(object)record.GetInt16(ordinal);
        }
        if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
        {
            return (T)(object)record.GetInt32(ordinal);
        }
        if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
        {
            return (T)(object)record.GetInt64(ordinal);
        }
        if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
        {
            return (T)(object)record.GetFloat(ordinal);
        }
        if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
        {
            return (T)(object)record.GetDouble(ordinal);
        }
        if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
        {
            return (T)(object)record.GetDecimal(ordinal);
        }
        if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
        {
            return (T)(object)record.GetDateTime(ordinal);
        }
        if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
        {
            return (T)(object)record.GetBoolean(ordinal);
        }
        if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
        {
            return (T)(object)record.GetByte(ordinal);
        }
        if (typeof(T) == typeof(char) || typeof(T) == typeof(char?))
        {
            return (T)(object)record.GetChar(ordinal);
        }
        return UnwrapSqlValue<T>(record.GetValue(ordinal));
    }

    /// <summary>
    /// Return the value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/> to act on.</param>
    /// <param name="fieldName">The name of the field to find.</param>
    /// <returns>The field value.</returns>
    public static object GetValue(this IDataRecord record, string fieldName)
    {
        if (record == null)
        {
            throw new ArgumentNullException(nameof(record));
        }
        var ordinal = record.GetOrdinal(fieldName);
        if (ordinal == -1)
        {
            throw new ArgumentException(string.Format(Strings.FieldCannotBeFound, fieldName));
        }
        return UnwrapSqlValue(record.GetValue(ordinal));
    }
}