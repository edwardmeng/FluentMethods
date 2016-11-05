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
        public void BitwiseAndAssign()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(3)),
                variable.AndAssign(Expression.Constant(6)),
                variable);
            Assert.Equal(2, expression.ToLambda<Func<int>>().Compile()());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LogicAndAssign()
        {
            var variable = Expression.Variable(typeof(bool));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(true)),
                variable.AndAssign(Expression.Constant(false)),
                variable);
            Assert.Equal(false, expression.ToLambda<Func<bool>>().Compile()());
        }
    }
}
