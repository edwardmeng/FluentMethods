using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentMethods.UnitTests
{
    public partial class ExpressionFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MemberInit()
        {
#if NetCore
            var property = typeof(ObjectFixture.Product).GetTypeInfo().GetProperty("Title");
#else
            var property = typeof(ObjectFixture.Product).GetProperty("Title");
#endif
            var lambda = Expression.New(typeof(ObjectFixture.Product)).MemberInit(Expression.Bind(property, Expression.Constant("Fizz")))
                .ToLambda<Func<ObjectFixture.Product>>().Compile();
            var product = lambda();
            Assert.NotNull(product);
            Assert.Equal("Fizz", product.Title);
        }
    }
}
