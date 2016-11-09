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
        public void ReferenceEqual()
        {
            var parameterX = Expression.Parameter(typeof(object), "x");
            var parameterY = Expression.Parameter(typeof(object), "y");
            var lambda = parameterX.ReferenceEqual(parameterY).ToLambda<Func<object, object, bool>>(parameterX, parameterY).Compile();
            var instance = new Version("1.0.1");
            Assert.True(lambda(instance, instance));
            Assert.False(lambda(new Version("1.0.1"), new Version("1.0.1")));
        }
    }
}
