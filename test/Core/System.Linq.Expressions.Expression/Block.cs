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
        public void Block()
        {
            var variable = Expression.Variable(typeof(int));
            var expression = new Expression[]
            {
                Expression.Assign(variable, Expression.Constant(1)),
                Expression.AddAssign(variable,Expression.Constant(2)),
                variable
            }.Block(variable);
            Assert.Equal(3, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
