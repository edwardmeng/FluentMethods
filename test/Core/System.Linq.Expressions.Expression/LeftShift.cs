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
        public void LeftShift()
        {
            var expression = Expression.Constant(2).LeftShift(Expression.Constant(2));
            Assert.Equal(8, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
