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
        public void LessThan()
        {
            var parameterX = Expression.Parameter(typeof(int), "x");
            var parameterY = Expression.Parameter(typeof(int), "y");
            var expression = parameterX.LessThan(parameterY);
            var lambda = expression.ToLambda<Func<int, int, bool>>(parameterX, parameterY).Compile();
            Assert.False(lambda(2, 2));
            Assert.True(lambda(2, 3));
            Assert.False(lambda(3, 2));
        }
    }
}
