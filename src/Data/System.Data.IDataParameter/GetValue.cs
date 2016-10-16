using System;
using System.Data;

public static partial class Extensions
{
    /// <summary>
    /// Return the value of the parameter.
    /// </summary>
    /// <param name="parameter">The <see cref="IDbDataParameter"/> to get value.</param>
    /// <returns>The parameter value.</returns>
    public static T GetValue<T>(this IDbDataParameter parameter)
    {
        if (parameter == null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }
        if (parameter.IsDBNull() && (!typeof(T).IsValueType || (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))))
            return default(T);
        return UnwrapSqlValue<T>(parameter.Value);
    }
}