using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Creates a <see cref="BlockExpression"/> that contains the given variables and expressions.
    /// </summary>
    /// <param name="expressions">The expressions in the block.</param>
    /// <param name="variables">The variables in the block.</param>
    /// <param name="type">The result type of the block.</param>
    /// <returns>The created <see cref="BlockExpression"/>.</returns>
    public static BlockExpression Block(this IEnumerable<Expression> expressions, IEnumerable<ParameterExpression> variables = null, Type type = null)
    {
        return type == null
            ? (variables == null ? Expression.Block(expressions) : Expression.Block(variables, expressions))
            : (variables == null ? Expression.Block(type, expressions) : Expression.Block(type, variables, expressions));
    }

}