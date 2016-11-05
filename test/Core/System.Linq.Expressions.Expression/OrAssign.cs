using System;
using System.Linq.Expressions;

namespace FluentMethods.UnitTests
{
    public partial class ExpressionFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BitwiseOrAssign()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(3)),
                variable.OrAssign(Expression.Constant(6)),
                variable);
            Assert.Equal(7, expression.ToLambda<Func<int>>().Compile()());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LogicOrAssign()
        {
            var variable = Expression.Variable(typeof(bool));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(true)),
                variable.OrAssign(Expression.Constant(false)),
                variable);
            Assert.Equal(true, expression.ToLambda<Func<bool>>().Compile()());
        }
    }
}
