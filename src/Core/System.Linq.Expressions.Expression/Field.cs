using System;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MemberExpression"/> that represents accessing a field.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance field accessing.</param>
    /// <param name="field">A <see cref="FieldInfo"/> to be accessed.</param>
    /// <returns>A <see cref="MemberExpression"/> that represents an instance field accessing.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="field"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// The type of <paramref name="instance"/> is not assignable to the declaring type of the field represented by <paramref name="field"/>.
    /// </exception>
    public static MemberExpression Field(this Expression instance, FieldInfo field)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Field(instance, field);
    }

    /// <summary>
    /// Creates a <see cref="MemberExpression"/> that represents accessing a field given the name of the field.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> whose Type contains a field named <paramref name="fieldName"/>.</param>
    /// <param name="fieldName">The name of a field to be accessed.</param>
    /// <returns>A <see cref="MemberExpression"/> that represents an instance field accessing.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="fieldName"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// No field named <paramref name="fieldName"/> is defined in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MemberExpression Field(this Expression instance, string fieldName)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }
        return Expression.Field(instance, fieldName);
    }
}