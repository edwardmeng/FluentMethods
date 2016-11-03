using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    public static MemberExpression Field(this Expression expression, FieldInfo field)
    {
        return Expression.Field(expression, field);
    }

    public static MemberExpression Field(this Expression expression, string fieldName)
    {
        return Expression.Field(expression, fieldName);
    }
}