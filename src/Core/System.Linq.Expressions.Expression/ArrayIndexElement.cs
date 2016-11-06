using System.Collections.Generic;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents applying an array index operator to an array of rank more than one.
    /// </summary>
    /// <param name="array">An <see cref="Expression"/> that represents the array to access.</param>
    /// <param name="indexes">An <see cref="IEnumerable{Expression}"/> that represents the indices to applying the array index operator.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents applying an array index operator.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="array"/> or <paramref name="indexes"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <paramref name="array"/> does not represent an array type.
    /// -or-
    /// The rank of <paramref name="array"/> does not match the number of elements in <paramref name="indexes"/>.
    /// -or-
    /// The type of one or more elements of indexes does not represent the <see cref="int"/> type.
    /// </exception>
    public static MethodCallExpression ArrayIndexElement(this Expression array, IEnumerable<Expression> indexes)
    {
        return Expression.ArrayIndex(array, indexes);
    }

    /// <summary>
    /// Creates a <see cref="MethodCallExpression"/> that represents applying an array index operator to a multidimensional array.
    /// </summary>
    /// <param name="array">An <see cref="Expression"/> that represents the array to access.</param>
    /// <param name="indexes">An <see cref="IEnumerable{Expression}"/> that represents the indices to applying the array index operator.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents applying an array index operator.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="array"/> or <paramref name="indexes"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <paramref name="array"/> does not represent an array type.
    /// -or-
    /// The rank of <paramref name="array"/> does not match the number of elements in <paramref name="indexes"/>.
    /// -or-
    /// The type of one or more elements of indexes does not represent the <see cref="int"/> type.
    /// </exception>
    public static MethodCallExpression ArrayIndexElement(this Expression array, params Expression[] indexes)
    {
        return Expression.ArrayIndex(array, indexes);
    }

    /// <summary>
    /// Creates a <see cref="BinaryExpression"/> that represents applying an array index operator to an array of rank one.
    /// </summary>
    /// <param name="array">An <see cref="Expression"/> that represents the array to access.</param>
    /// <param name="index">An <see cref="Expression"/> that represents the index to applying the array index operator.</param>
    /// <returns>A <see cref="MethodCallExpression"/> that represents applying an array index operator.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="array"/> or <paramref name="index"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <paramref name="array"/> does not represent an array type.
    /// -or-
    /// The <paramref name="array"/> represents an array type whose rank is not 1.
    /// -or-
    /// The <paramref name="index"/> does not represent the <see cref="int"/> type.
    /// </exception>
    public static BinaryExpression ArrayIndexElement(this Expression array, Expression index)
    {
        return Expression.ArrayIndex(array, index);
    }

}