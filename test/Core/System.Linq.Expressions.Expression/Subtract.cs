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
        public void Subtract()
        {
            var expression = Expression.Constant(3).Subtract(Expression.Constant(2));
            Assert.Equal(1, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
