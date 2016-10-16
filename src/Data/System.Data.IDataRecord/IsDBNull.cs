using System;
using System.Data;
using System.Data.SqlTypes;
using FluentMethods.Data;

public static partial class Extensions
{
    /// <summary>
    /// Return whether the specified field is set to null.
    /// </summary>
    /// <param name="reader">The <see cref="IDataRecord"/> to act on.</param>
    /// <param name="fieldName">The name of the field to find.</param>
    /// <returns><c>true</c> if the specified field is set to null; otherwise, <c>false</c>.</returns>
    public static bool IsDBNull(this IDataRecord reader, string fieldName)
    {
        if (reader == null)
        {
            throw new ArgumentNullException(nameof(reader));
        }
        var ordinal = reader.GetOrdinal(fieldName);
        if (ordinal == -1)
        {
            throw new ArgumentException(string.Format(Strings.FieldCannotBeFound, fieldName));
        }
        return reader.IsDBNull(ordinal) || ((reader.GetValue(ordinal) as INullable)?.IsNull ?? false);
    }
}