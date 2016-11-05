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
        public void RightShift()
        {
            var expression = Expression.Constant(8).RightShift(Expression.Constant(2));
            Assert.Equal(2, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
