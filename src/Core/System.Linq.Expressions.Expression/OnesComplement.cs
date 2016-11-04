using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="UnaryExpression"/> that representing the ones complement.
    /// </summary>
    /// <param name="expression">The <see cref="Expression"/> to perform the ones complement operation.</param>
    /// <returns>A <see cref="UnaryExpression"/> represents the ones complement operation of the <paramref name="expression"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="expression"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The ones complement operator is not defined for the type of <paramref name="expression"/>.</exception>
    public static UnaryExpression OnesComplement(this Expression expression)
    {
        return Expression.OnesComplement(expression);
    }
}