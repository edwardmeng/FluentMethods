using System.Collections.Generic;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Represents an expression that creates a new object and initializes a property of the object.
    /// </summary>
    /// <param name="expression">A <see cref="NewExpression"/> represents the expression to be bound to.</param>
    /// <param name="bindings">An <see cref="IEnumerable{T}"/> that contains <see cref="MemberBinding"/> objects to use to bind field or property.</param>
    /// <returns>A <see cref="MemberInitExpression"/> that represents the initialization expression.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="bindings"/> or <paramref name="expression"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <see cref="MemberBinding.Member"/> property of an element of <paramref name="bindings"/> does not represent a member of the type that <paramref name="expression"/> represents.
    /// </exception>
    public static MemberInitExpression MemberInit(this NewExpression expression, IEnumerable<MemberBinding> bindings)
    {
        return Expression.MemberInit(expression, bindings);
    }

    /// <summary>
    /// Represents an expression that creates a new object and initializes a property of the object.
    /// </summary>
    /// <param name="expression">A <see cref="NewExpression"/> represents the expression to be bound to.</param>
    /// <param name="bindings">An array of <see cref="MemberBinding"/> objects to use to bind fields or properties.</param>
    /// <returns>A <see cref="MemberInitExpression"/> that represents the initialization expression.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="bindings"/> or <paramref name="expression"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <see cref="MemberBinding.Member"/> property of an element of <paramref name="bindings"/> does not represent a member of the type that <paramref name="expression"/> represents.
    /// </exception>
    public static MemberInitExpression MemberInit(this NewExpression expression, params MemberBinding[] bindings)
    {
        return Expression.MemberInit(expression, bindings);
    }
}