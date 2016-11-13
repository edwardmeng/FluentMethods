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
            var property = typeof(ObjectFixture.Product).GetTypeInfo().GetProperty("Title");
#else
            var property = typeof(ObjectFixture.Product).GetProperty("Title");
#endif
            var expression = Expression.MemberInit(Expression.New(typeof(ObjectFixture.Product)), Expression.Constant("Fizz").BindTo(property));
            var product = expression.ToLambda<Func<ObjectFixture.Product>>().Compile()();
            Assert.Equal("Fizz", product.Title);
        }
    }
}
