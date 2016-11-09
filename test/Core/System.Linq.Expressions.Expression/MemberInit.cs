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
        public void MemberInit()
        {
            var lambda = Expression.New(typeof(ObjectFixture.Product)).MemberInit(Expression.Bind(typeof(ObjectFixture.Product).GetProperty("Title"), Expression.Constant("Fizz")))
                .ToLambda<Func<ObjectFixture.Product>>().Compile();
            var product = lambda();
            Assert.NotNull(product);
            Assert.Equal("Fizz", product.Title);
        }
    }
}
