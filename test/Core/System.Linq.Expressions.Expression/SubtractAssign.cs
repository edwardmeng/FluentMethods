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
        public void SubtractAssign()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(3)),
                variable.SubtractAssign(Expression.Constant(2)),
                variable);
            Assert.Equal(1, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
