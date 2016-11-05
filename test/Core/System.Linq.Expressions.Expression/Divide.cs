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
        public void Divide()
        {
            var expression = Expression.Constant(10).Divide(Expression.Constant(2));
            Assert.Equal(5, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
