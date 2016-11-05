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
        public void Add()
        {
            var expression = Expression.Constant(1).Add(Expression.Constant(2));
            Assert.Equal(3, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
