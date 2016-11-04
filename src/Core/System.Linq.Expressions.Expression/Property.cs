using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MemberExpression"/> that represents accessing a property given the name of the property.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> whose Type contains a property named <paramref name="propertyName"/>.</param>
    /// <param name="propertyName">The name of a property to be accessed.</param>
    /// <returns>A <see cref="MemberExpression"/> that represents an instance property accessing.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="instance"/> or <paramref name="propertyName"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// No property named <paramref name="propertyName"/> is defined in the type of <paramref name="instance"/> or its base types.
    /// </exception>
    public static MemberExpression Property(this Expression instance, string propertyName)
    {
        return Expression.Property(instance, propertyName);
    }

    /// <summary>
    /// Creates a <see cref="MemberExpression"/> that represents accessing a property.
    /// </summary>
    /// <param name="instance">An <see cref="Expression"/> that specifies the instance for an instance property accessing.</param>
    /// <param name="property">A <see cref="PropertyInfo"/> to be accessed.</param>
    /// <returns>A <see cref="MemberExpression"/> that represents an instance property accessing.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="instance"/> or <paramref name="property"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The type of <paramref name="instance"/> is not assignable to the declaring type of the property represented by <paramref name="property"/>.
    /// </exception>
    public static MemberExpression Property(this Expression instance, PropertyInfo property)
    {
        return Expression.Property(instance, property);
    }
}