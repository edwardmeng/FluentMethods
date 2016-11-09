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
    public static BlockExpression Block(this IEnumerable<Expression> expressions, IEnumerable<ParameterExpression> variables, Type type)
    {
        return type == null
            ? (variables == null ? Expression.Block(expressions) : Expression.Block(variables, expressions))
            : (variables == null ? Expression.Block(type, expressions) : Expression.Block(type, variables, expressions));
    }

    /// <summary>
    /// Creates a <see cref="BlockExpression"/> that contains the given variables and expressions.
    /// </summary>
    /// <param name="expressions">The expressions in the block.</param>
    /// <param name="variables">The variables in the block.</param>
    /// <returns>The created <see cref="BlockExpression"/>.</returns>
    public static BlockExpression Block(this IEnumerable<Expression> expressions, IEnumerable<ParameterExpression> variables)
    {
        return expressions.Block(variables, null);
    }

    /// <summary>
    /// Creates a <see cref="BlockExpression"/> that contains the given variables and expressions.
    /// </summary>
    /// <param name="expressions">The expressions in the block.</param>
    /// <param name="variables">The variables in the block.</param>
    /// <returns>The created <see cref="BlockExpression"/>.</returns>
    public static BlockExpression Block(this IEnumerable<Expression> expressions, params ParameterExpression[] variables)
    {
        return expressions.Block((IEnumerable<ParameterExpression>)variables);
    }

    /// <summary>
    /// Creates a <see cref="BlockExpression"/> that contains the given expressions.
    /// </summary>
    /// <param name="expressions">The expressions in the block.</param>
    /// <param name="type">The result type of the block.</param>
    /// <returns>The created <see cref="BlockExpression"/>.</returns>
    public static BlockExpression Block(this IEnumerable<Expression> expressions, Type type)
    {
        return expressions.Block(null, type);
    }
}