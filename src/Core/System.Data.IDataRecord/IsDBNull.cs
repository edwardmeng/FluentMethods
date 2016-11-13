using System;
using System.Data;
using System.Data.SqlTypes;

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
        int ordinal;
        try
        {
            ordinal = reader.GetOrdinal(fieldName);
        }
        catch (ArgumentOutOfRangeException)
        {
            ordinal = -1;
        }
        if (ordinal == -1)
        {
            throw new ArgumentException(string.Format(FluentMethods.Strings.FieldCannotBeFound, fieldName), nameof(fieldName));
        }
        return reader.IsDBNull(ordinal) || ((reader.GetValue(ordinal) as INullable)?.IsNull ?? false);
    }
}