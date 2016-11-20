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
            var property = typeof(Product).GetTypeInfo().GetProperty("Title");
#else
            var property = typeof(Product).GetProperty("Title");
#endif
            var lambda = Expression.New(typeof(Product)).MemberInit(Expression.Bind(property, Expression.Constant("Fizz")))
                .ToLambda<Func<Product>>().Compile();
            var product = lambda();
            Assert.NotNull(product);
            Assert.Equal("Fizz", product.Title);
        }
    }
}
