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
        public void Equal()
        {
            var parameterX = Expression.Parameter(typeof(int), "x");
            var parameterY = Expression.Parameter(typeof(int), "y");
            var expression = parameterX.Equal(parameterY);
            var lambda = expression.ToLambda<Func<int, int, bool>>(parameterX, parameterY).Compile();
            Assert.True(lambda(2, 2));
            Assert.False(lambda(2, 3));
        }
    }
}
