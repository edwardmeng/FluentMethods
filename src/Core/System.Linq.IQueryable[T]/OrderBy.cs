using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
#if Net35
    private static readonly System.Collections.Generic.Dictionary<Pair<Type, string>, Expression> _orderMemberCache = new System.Collections.Generic.Dictionary<Pair<Type, string>, Expression>();
    private static readonly object _orderMemberCacheLock = new object();
    private static Expression GetPropertyOrFieldExpression(Type elementType, string name)
    {
        lock (_orderMemberCacheLock)
        {
            return _orderMemberCache.GetOrAdd(new Pair<Type, string>(elementType, name), key => CreatePropertyOrFieldExpression(key.First, key.Second));
        }
    }
#else
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<Tuple<Type,string>, Expression> _orderMemberCache = new System.Collections.Concurrent.ConcurrentDictionary<Tuple<Type, string>, Expression>();

    private static Expression GetPropertyOrFieldExpression(Type elementType, string name)
    {
        return _orderMemberCache.GetOrAdd(Tuple.Create(elementType, name), key => CreatePropertyOrFieldExpression(key.Item1, key.Item2));
    }
#endif

    /// <summary>
    /// Sorts the elements of a sequence according with a specified expression.
    /// </summary>
    /// <param name="source">A sequence of values to order.</param>
    /// <param name="ordering">An expression to sort elements in the <paramref name="source"/>.</param>
    /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according by using the <paramref name="ordering"/> expression.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="ordering"/> is <see langword="null"/> or empty string("").</exception>
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (string.IsNullOrEmpty(ordering)) throw new ArgumentException(FluentMethods.Strings.CannotNullOrEmpty, nameof(ordering));
        var expression = source.Expression;
        var ascendingMethod = "OrderBy";
        var descendingMethod = "OrderByDescending";
        foreach (var part in ordering.Split(',').Select(x => x.Trim()))
        {
            if (string.IsNullOrEmpty(part))
            {
                throw new ArgumentException(string.Format(FluentMethods.Strings.InvalidOrderSyntax, ordering), nameof(ordering));
            }
            var ascending = true;
            string fieldName = part;
            if (part.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase))
            {
                fieldName = part.Substring(0, part.Length - 4).Trim();
            }
            else if (part.EndsWith(" DESC", StringComparison.OrdinalIgnoreCase))
            {
                ascending = false;
                fieldName = part.Substring(0, part.Length - 5).Trim();
            }
            if (fieldName.Contains(' '))
            {
                throw new ArgumentException(string.Format(FluentMethods.Strings.InvalidOrderSyntax, ordering), nameof(ordering));
            }
            var orderExpression = GetPropertyOrFieldExpression(typeof(T), fieldName);
            if (orderExpression == null)
            {
                throw new InvalidOperationException(string.Format(FluentMethods.Strings.CannotFindTypeMember, fieldName, source.ElementType));
            }
#if NetCore
            var memberType = orderExpression.Type.GetTypeInfo().GetGenericArguments()[0].GetTypeInfo().GetGenericArguments()[1];
#else
            var memberType = orderExpression.Type.GetGenericArguments()[0].GetGenericArguments()[1];
#endif
            expression = Expression.Call(typeof(Queryable), ascending ? ascendingMethod : descendingMethod, new[] { source.ElementType, memberType }, expression, orderExpression);
            ascendingMethod = "ThenBy";
            descendingMethod = "ThenByDescending";
        }
        return (IOrderedQueryable<T>)source.Provider.CreateQuery(expression);
    }

    private static Expression CreatePropertyOrFieldExpression(Type elementType, string name)
    {
#if NetCore
        var properties = elementType.GetTypeInfo().GetProperties(BindingFlags.Public|BindingFlags.Instance);
        var fields = elementType.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Instance);
#else
        var properties = elementType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = elementType.GetFields(BindingFlags.Public | BindingFlags.Instance);
#endif
        var parameter = Expression.Parameter(elementType, "x");
        var property = properties.SingleOrDefault(p => p.Name == name);
        if (property != null)
        {
            return Expression.Quote(Expression.Lambda(Expression.Property(parameter, property), parameter));
        }
        var field = fields.SingleOrDefault(f => f.Name == name);
        if (field != null)
        {
            return Expression.Quote(Expression.Lambda(Expression.Field(parameter, field), parameter));
        }
        property = properties.SingleOrDefault(p => string.Equals(p.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (property != null)
        {
            return Expression.Quote(Expression.Lambda(Expression.Property(parameter, property), parameter));
        }
        field = fields.SingleOrDefault(f => string.Equals(f.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (field != null)
        {
            return Expression.Quote(Expression.Lambda(Expression.Field(parameter, field), parameter));
        }
        return null;
    }
}