using System.Linq.Expressions;

public static partial class Extensions
{
    public static MemberExpression PropertyOrField(this Expression expression, string propertyOrFieldName)
    {
        return Expression.PropertyOrField(expression, propertyOrFieldName);
    }
}