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
        public void Multiply()
        {
            var expression = Expression.Constant(2).Multiply(Expression.Constant(3));
            Assert.Equal(6, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
