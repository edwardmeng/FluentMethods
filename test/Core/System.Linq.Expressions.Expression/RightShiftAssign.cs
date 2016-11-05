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
        public void RightShiftAssign()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(8)),
                variable.RightShiftAssign(Expression.Constant(2)),
                variable);
            Assert.Equal(2, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
