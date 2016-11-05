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
        public void BitwiseAnd()
        {
            var expression = Expression.Constant(3).And(Expression.Constant(6));
            Assert.Equal(2, expression.ToLambda<Func<int>>().Compile()());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LogicAnd()
        {
            var expression = Expression.Constant(true).And(Expression.Constant(false));
            Assert.Equal(false, expression.ToLambda<Func<bool>>().Compile()());
        }
    }
}
