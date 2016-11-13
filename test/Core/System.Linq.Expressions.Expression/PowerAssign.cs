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
        public void PowerAssign()
        {
            var variable = Expression.Variable(typeof(double));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant((double)2)),
                variable.PowerAssign(Expression.Constant((double)3)),
                variable);
            Assert.Equal((double)8, expression.ToLambda<Func<double>>().Compile()());
        }
    }
}
