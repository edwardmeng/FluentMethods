using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="NewExpression"/> that represents calling the specified constructor with the specified arguments.
    /// </summary>
    /// <param name="constructor">The <see cref="ConstructorInfo"/> to be used to create new instance.</param>
    /// <param name="arguments">An array of <see cref="Expression"/> objects used to call the constructor.</param>
    /// <returns>A <see cref="NewExpression"/> that represents calling the constructor.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="constructor"/> is null.
    /// -or-
    /// An element of <paramref name="arguments"/> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// The length of <paramref name="arguments"/> does match the number of parameters for the constructor that <paramref name="constructor"/> represents.
    /// -or-
    /// The <see cref="Expression.Type"/> property of an element of <paramref name="arguments"/> is not assignable to the type of the corresponding parameter of the constructor that <paramref name="constructor"/> represents.
    /// </exception>
    public static NewExpression New(this ConstructorInfo constructor, params Expression[] arguments)
    {
        return Expression.New(constructor, arguments);
    }

    /// <summary>
    /// Creates a <see cref="NewExpression"/> that represents calling the specified constructor with the specified arguments.
    /// </summary>
    /// <param name="constructor">The <see cref="ConstructorInfo"/> to be used to create new instance.</param>
    /// <param name="arguments">An <see cref="IEnumerable{Expression}"/> used to call the constructor.</param>
    /// <returns>A <see cref="NewExpression"/> that represents calling the constructor.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="constructor"/> is null.
    /// -or-
    /// An element of <paramref name="arguments"/> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// The length of <paramref name="arguments"/> does match the number of parameters for the constructor that <paramref name="constructor"/> represents.
    /// -or-
    /// The <see cref="Expression.Type"/> property of an element of <paramref name="arguments"/> is not assignable to the type of the corresponding parameter of the constructor that <paramref name="constructor"/> represents.
    /// </exception>
    public static NewExpression New(this ConstructorInfo constructor, IEnumerable<Expression> arguments)
    {
        return Expression.New(constructor, arguments);
    }

    /// <summary>
    /// Creates a <see cref="NewExpression"/> that represents calling the specified constructor that takes no arguments.
    /// </summary>
    /// <param name="constructor">The <see cref="ConstructorInfo"/> to be used to create new instance.</param>
    /// <returns>A <see cref="NewExpression"/> that represents calling the constructor.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="constructor"/> is null.</exception>
    /// <exception cref="System.ArgumentException">The constructor that <paramref name="constructor"/> represents has at least one parameter.</exception>
    public static NewExpression New(this ConstructorInfo constructor)
    {
        return Expression.New(constructor);
    }
}