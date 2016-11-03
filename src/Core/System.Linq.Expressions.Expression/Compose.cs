using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    /// <summary>
    /// Create a lambda expression to compose the lambda expression operands with the specified strategy.
    /// </summary>
    /// <typeparam name="T">The type of the lambda expression represents.</typeparam>
    /// <param name="left">The lambda expression that represents the left operand.</param>
    /// <param name="right">The lambda expression that represents the right operand.</param>
    /// <param name="merge">The strategy to compose the operands.</param>
    /// <returns>A lambda expression that compose the left and right operands.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">The specified strategy is not defined for the type of <paramref name="left"/> and <paramref name="right"/>.</exception>
    public static Expression<T> Compose<T>(this Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> merge)
    {
        if (left == null)
        {
            throw new ArgumentNullException(nameof(left));
        }
        if (right == null)
        {
            throw new ArgumentNullException(nameof(right));
        }
        var map = left.Parameters
            .Select((f, i) => new { f, s = right.Parameters[i] })
            .ToDictionary(p => p.s, p => p.f);
        var secondBody = ParameterRebinder.ReplaceParameters(map, right.Body);
        return Expression.Lambda<T>(merge(left.Body, secondBody), left.Parameters);
    }

    private class ParameterRebinder : ExpressionVisitor
    {
        readonly Dictionary<ParameterExpression, ParameterExpression> map;
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterRebinder"/> class.
        /// </summary>
        /// <param name="map">The map.</param>
        ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        /// <summary>
        /// Replaces the parameters.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>Expression</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;

            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}