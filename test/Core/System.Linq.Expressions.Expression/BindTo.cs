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
        public void BindTo()
        {
            var expression = Expression.MemberInit(Expression.New(typeof(ObjectFixture.Product)), Expression.Constant("Fizz").BindTo(typeof(ObjectFixture.Product).GetProperty("Title")));
            var product = expression.ToLambda<Func<ObjectFixture.Product>>().Compile()();
            Assert.Equal("Fizz", product.Title);
        }
    }
}
