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
        public void BitwiseOr()
        {
            var expression = Expression.Constant(3).Or(Expression.Constant(6));
            Assert.Equal(7, expression.ToLambda<Func<int>>().Compile()());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LogicOr()
        {
            var expression = Expression.Constant(true).Or(Expression.Constant(false));
            Assert.Equal(true, expression.ToLambda<Func<bool>>().Compile()());
        }
    }
}
