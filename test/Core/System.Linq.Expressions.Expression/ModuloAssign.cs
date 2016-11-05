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
        public void ModuloAssign()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { variable },
                Expression.Assign(variable, Expression.Constant(19)),
                variable.ModuloAssign(Expression.Constant(7)),
                variable);
            Assert.Equal(5, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
