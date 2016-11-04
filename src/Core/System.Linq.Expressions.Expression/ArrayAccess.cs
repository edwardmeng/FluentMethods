using System.Collections.Generic;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates an <see cref="IndexExpression"/> to access a multidimensional array.
    /// </summary>
    /// <param name="array">An expression that represents the multidimensional array.</param>
    /// <param name="indexes">An <see cref="IEnumerable{Expression}"/> containing expressions used to index the array.</param>
    /// <returns>The created <see cref="IndexExpression"/> to access a multidimensional array.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="array"/> or <paramref name="indexes"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <paramref name="array"/> does not represent an array type.
    /// -or-
    /// The rank of <paramref name="array"/> does not match the number of elements in <paramref name="indexes"/>.
    /// -or-
    /// The type of one or more elements of indexes does not represent the <see cref="int"/> type.
    /// </exception>
    public static IndexExpression ArrayAccess(this Expression array, IEnumerable<Expression> indexes)
    {
        return Expression.ArrayAccess(array, indexes);
    }
    /// <summary>
    /// Creates an <see cref="IndexExpression"/> to access an array.
    /// </summary>
    /// <param name="array">An expression representing the array to index.</param>
    /// <param name="indexes">An array that contains expressions used to index the array.</param>
    /// <returns>The created <see cref="IndexExpression"/> to access an array.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="array"/> or <paramref name="indexes"/> is null.</exception>
    /// <exception cref="System.ArgumentException">
    /// The <paramref name="array"/> does not represent an array type.
    /// -or-
    /// The rank of <paramref name="array"/> does not match the number of elements in <paramref name="indexes"/>.
    /// -or-
    /// The type of one or more elements of indexes does not represent the <see cref="int"/> type.
    /// </exception>
    public static IndexExpression ArrayAccess(this Expression array, params Expression[] indexes)
    {
        return Expression.ArrayAccess(array, indexes);
    }
}