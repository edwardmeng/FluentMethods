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
        public void BitwiseNot()
        {
            var expression = Expression.Constant(3).Not();
            Assert.Equal(-4, expression.ToLambda<Func<int>>().Compile()());

        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LogicNot()
        {
            var expression = Expression.Constant(true).Not();
            Assert.Equal(false, expression.ToLambda<Func<bool>>().Compile()());
        }
    }
}
