using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    public static MemberExpression Property(this Expression expression, string propertyName)
    {
        return Expression.Property(expression, propertyName);
    }

    public static MemberExpression Property(this Expression expression, PropertyInfo property)
    {
        return Expression.Property(expression, property);
    }
}