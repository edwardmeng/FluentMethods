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
        public void Is()
        {
            var parameter = Expression.Parameter(typeof(object), "x");
            var expression = parameter.Is<int>();
            var lambda = expression.ToLambda<Func<object,bool>>(parameter).Compile();
            Assert.False(lambda("Fizz"));
            Assert.True(lambda(2));
        }
    }
}
