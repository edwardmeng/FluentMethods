using System;
using System.Linq;
using System.Linq.Expressions;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Sorts the elements of a sequence according with a specified expression.
    /// </summary>
    /// <param name="source">A sequence of values to order.</param>
    /// <param name="ordering">An expression to sort elements in the <paramref name="source"/>.</param>
    /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according by using the <paramref name="ordering"/> expression.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="ordering"/> is <see langword="null"/> or empty string("").</exception>
    public static IOrderedQueryable OrderBy(this IQueryable source, string ordering)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (string.IsNullOrEmpty(ordering)) throw new ArgumentException(Strings.CannotNullOrEmpty, nameof(ordering));
        var expression = source.Expression;
        var ascendingMethod = "OrderBy";
        var descendingMethod = "OrderByDescending";
        foreach (var part in ordering.Split(',').Select(x => x.Trim()))
        {
            if (string.IsNullOrEmpty(part))
            {
                throw new ArgumentException(string.Format(Strings.InvalidOrderSyntax, ordering), nameof(ordering));
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
                throw new ArgumentException(string.Format(Strings.InvalidOrderSyntax, ordering), nameof(ordering));
            }
            Type fieldType;
            var orderExpression = GetPropertyOrFieldExpression(source.ElementType,fieldName,out fieldType);
            if (orderExpression == null)
            {
                throw new InvalidOperationException(string.Format(Strings.CannotFindTypeMember, fieldName, source.ElementType));
            }
            expression = Expression.Call(typeof(Queryable), ascending ? ascendingMethod : descendingMethod, new[] {source.ElementType, fieldType}, expression, orderExpression);
            ascendingMethod = "ThenBy";
            descendingMethod = "ThenByDescending";
        }
        return (IOrderedQueryable)source.Provider.CreateQuery(expression);
    }

    private static Expression GetPropertyOrFieldExpression(Type elementType, string name, out Type memberType)
    {
        memberType = null;
        var properties = elementType.GetProperties();
        var fields = elementType.GetFields();
        var parameter = Expression.Parameter(elementType);
        var property = properties.SingleOrDefault(p => p.Name == name);
        if (property != null)
        {
            memberType = property.PropertyType;
            return Expression.Quote(Expression.Lambda(Expression.Property(parameter, property), parameter));
        }
        var field = fields.SingleOrDefault(f => f.Name == name);
        if (field != null)
        {
            memberType = field.FieldType;
            return Expression.Quote(Expression.Lambda(Expression.Field(parameter, field), parameter));
        }
        property = properties.SingleOrDefault(p => string.Equals(p.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (property != null)
        {
            memberType = property.PropertyType;
            return Expression.Quote(Expression.Lambda(Expression.Property(parameter, property), parameter));
        }
        field = fields.SingleOrDefault(f => string.Equals(f.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (field != null)
        {
            memberType = field.FieldType;
            return Expression.Quote(Expression.Lambda(Expression.Field(parameter, field), parameter));
        }
        return null;
    }
}