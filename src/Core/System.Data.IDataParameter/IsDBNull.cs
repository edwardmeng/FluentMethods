using System;
using System.Data;
using System.Data.SqlTypes;

public static partial class Extensions
{
    /// <summary>
    /// Return whether the parameter is set to null.
    /// </summary>
    /// <param name="parameter">The <see cref="IDataRecord"/> to act on.</param>
    /// <returns><c>true</c> if the parameter is set to null; otherwise, <c>false</c>.</returns>
    public static bool IsDBNull(this IDbDataParameter parameter)
    {
        if (parameter == null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }
        var value = parameter.Value;
        return value == null || value == DBNull.Value || ((value as INullable)?.IsNull??false);
    }
}