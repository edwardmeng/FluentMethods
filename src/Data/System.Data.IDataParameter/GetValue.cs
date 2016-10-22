using System;
using System.Data;
using System.Reflection;

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
#if NetCore
        if (parameter.IsDBNull() && (!typeof(T).GetTypeInfo().IsValueType || (typeof(T).GetTypeInfo().IsGenericType && typeof(T).GetTypeInfo().GetGenericTypeDefinition() == typeof(Nullable<>))))
#else
        if (parameter.IsDBNull() && (!typeof(T).IsValueType || (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))))
#endif
            return default(T);
        return UnwrapSqlValue<T>(parameter.Value);
    }
}