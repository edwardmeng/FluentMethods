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
        public void BindTo()
        {
#if NetCore
            var property = typeof(Product).GetTypeInfo().GetProperty("Title");
#else
            var property = typeof(Product).GetProperty("Title");
#endif
            var expression = Expression.MemberInit(Expression.New(typeof(Product)), Expression.Constant("Fizz").BindTo(property));
            var product = expression.ToLambda<Func<Product>>().Compile()();
            Assert.Equal("Fizz", product.Title);
        }
    }
}
