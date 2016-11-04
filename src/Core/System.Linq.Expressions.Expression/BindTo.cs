using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MemberAssignment"/> that represents the initialization of a field or property.
    /// </summary>
    /// <param name="expression">A <see cref="Expression"/> represents the expression to bind.</param>
    /// <param name="member">A <see cref="MemberInfo"/> represents the field or property to be bind to.</param>
    /// <returns>A <see cref="MemberAssignment"/> that represents the initialization of a field or property.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="member"/> or <paramref name="expression"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// <paramref name="member"/> does not represent a field or property.
    /// -or-
    /// The property represented by member does not have a set accessor.
    /// -or-
    /// The type of <paramref name="expression"/> is not assignable to the type of the field or property that <paramref name="member"/> represents.
    /// </exception>
    public static MemberAssignment BindTo(this Expression expression, MemberInfo member)
    {
        return Expression.Bind(member, expression);
    }
}