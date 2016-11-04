using System;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MemberExpression"/> that represents accessing either a field or a property.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that represents the object that the member belongs to. </param>
    /// <param name="member">The <see cref="MemberInfo"/> that describes the field or property to be accessed.</param>
    /// <returns>The <see cref="MemberExpression"/> that results from calling the appropriate factory method.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="instance"/> or <paramref name="member"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// <paramref name="member"/> does not represent a field or property.
    /// </exception>
    public static MemberExpression Member(this Expression instance, MemberInfo member)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.MakeMemberAccess(instance, member);
    }

    /// <summary>
    /// Creates a <see cref="MemberExpression"/> that represents accessing either a property or field.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that represents the object that the member belongs to. </param>
    /// <param name="propertyOrFieldName">The name of a property or field to be accessed.</param>
    /// <returns>A <see cref="MemberExpression"/> that results from calling the appropriate factory method.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="instance"/> or <paramref name="propertyOrFieldName"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// No property or field named <paramref name="propertyOrFieldName"/> is defined in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MemberExpression Member(this Expression instance, string propertyOrFieldName)
    {
        return Expression.PropertyOrField(instance, propertyOrFieldName);
    }
}