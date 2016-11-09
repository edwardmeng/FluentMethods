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
        public void ReferenceNotEqual()
        {
            var parameterX = Expression.Parameter(typeof(object), "x");
            var parameterY = Expression.Parameter(typeof(object), "y");
            var lambda = parameterX.ReferenceNotEqual(parameterY).ToLambda<Func<object, object, bool>>(parameterX, parameterY).Compile();
            var instance = new Version("1.0.1");
            Assert.False(lambda(instance, instance));
            Assert.True(lambda(new Version("1.0.1"), new Version("1.0.1")));
        }
    }
}
