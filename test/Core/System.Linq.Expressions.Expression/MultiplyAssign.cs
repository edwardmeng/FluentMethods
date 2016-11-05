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
        public void MultiplyAssign()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(2)),
                variable.MultiplyAssign(Expression.Constant(3)),
                variable);
            Assert.Equal(6, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
