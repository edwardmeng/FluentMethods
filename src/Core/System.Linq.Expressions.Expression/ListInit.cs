using System.Collections.Generic;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="ListInitExpression"/> that uses specified <see cref="ElementInit"/> objects to initialize a collection.
    /// </summary>
    /// <param name="newExpression">A <see cref="NewExpression"/> represents the collection to initialize.</param>
    /// <param name="initializers">An <see cref="IEnumerable{T}"/> that contains <see cref="ElementInit"/> objects to use to initialize elements of the collection.</param>
    /// <returns>A <see cref="ListInitExpression"/> that represents the initialization expression.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="newExpression"/> or <paramref name="initializers"/> is null.
    /// -or-
    /// One or more elements of <paramref name="initializers"/> are null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// The type that <paramref name="newExpression"/> represents does not implement <see cref="System.Collections.IEnumerable"/>.
    /// </exception>
    public static ListInitExpression ListInit(this NewExpression newExpression, IEnumerable<ElementInit> initializers)
    {
        return Expression.ListInit(newExpression, initializers);
    }

    /// <summary>
    /// Creates a <see cref="ListInitExpression"/> that uses a method named "Add" to add elements to a collection.
    /// </summary>
    /// <param name="newExpression">A <see cref="NewExpression"/> represents the collection to add elements to.</param>
    /// <param name="initializers">An <see cref="IEnumerable{T}"/> that contains <see cref="Expression"/> objects to use to add elements to the collection.</param>
    /// <returns>A <see cref="ListInitExpression"/> that represents the initialization expression.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="newExpression"/> or <paramref name="initializers"/> is null.
    /// -or-
    /// One or more elements of <paramref name="initializers"/> are null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// The type that <paramref name="newExpression"/> represents does not implement <see cref="System.Collections.IEnumerable"/>.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">
    /// There is no instance method named "Add" (case insensitive) declared in <paramref name="newExpression"/>.Type or its base type.
    /// -or-
    /// The add method on <paramref name="newExpression"/>.Type or its base type does not take exactly one argument.
    /// -or-
    /// The type represented by the <see cref="Expression.Type"/> property of the first element of initializers is not assignable to the argument type of the add method on <paramref name="newExpression"/>.Type or its base type.
    /// -or-
    /// More than one argument-compatible method named "Add" (case-insensitive) exists on <paramref name="newExpression"/>.Type and/or its base type.
    /// </exception>
    public static ListInitExpression ListInit(this NewExpression newExpression, IEnumerable<Expression> initializers)
    {
        return Expression.ListInit(newExpression, initializers);
    }

    /// <summary>
    /// Creates a <see cref="ListInitExpression"/> that uses specified <see cref="ElementInit"/> objects to initialize a collection.
    /// </summary>
    /// <param name="newExpression">A <see cref="NewExpression"/> represents the collection to initialize.</param>
    /// <param name="initializers">An array of <see cref="ElementInit"/> objects to use to initialize elements of the collection.</param>
    /// <returns>A <see cref="ListInitExpression"/> that represents the initialization expression.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="newExpression"/> or <paramref name="initializers"/> is null.
    /// -or-
    /// One or more elements of <paramref name="initializers"/> are null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// The type that <paramref name="newExpression"/> represents does not implement <see cref="System.Collections.IEnumerable"/>.
    /// </exception>
    public static ListInitExpression ListInit(this NewExpression newExpression, params ElementInit[] initializers)
    {
        return Expression.ListInit(newExpression, initializers);
    }

    /// <summary>
    /// Creates a <see cref="ListInitExpression"/> that uses a method named "Add" to add elements to a collection.
    /// </summary>
    /// <param name="newExpression">A <see cref="NewExpression"/> represents the collection to add elements to.</param>
    /// <param name="initializers">An array of <see cref="Expression"/> objects to use to add elements to the collection.</param>
    /// <returns>A <see cref="ListInitExpression"/> that represents the initialization expression.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="newExpression"/> or <paramref name="initializers"/> is null.
    /// -or-
    /// One or more elements of <paramref name="initializers"/> are null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// The type that <paramref name="newExpression"/> represents does not implement <see cref="System.Collections.IEnumerable"/>.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">
    /// There is no instance method named "Add" (case insensitive) declared in <paramref name="newExpression"/>.Type or its base type.
    /// -or-
    /// The add method on <paramref name="newExpression"/>.Type or its base type does not take exactly one argument.
    /// -or-
    /// The type represented by the <see cref="Expression.Type"/> property of the first element of initializers is not assignable to the argument type of the add method on <paramref name="newExpression"/>.Type or its base type.
    /// -or-
    /// More than one argument-compatible method named "Add" (case-insensitive) exists on <paramref name="newExpression"/>.Type and/or its base type.
    /// </exception>
    public static ListInitExpression ListInit(this NewExpression newExpression, params Expression[] initializers)
    {
        return Expression.ListInit(newExpression, initializers);
    }
}