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
        public void Field()
        {
            var parameter = Expression.Parameter(typeof(ObjectFixture.Product), "x");
            var expression = parameter.Field("Category");
            var lambda = expression.ToLambda<Func<ObjectFixture.Product, string>>(parameter).Compile();
            Assert.Equal("Fizz", lambda(new ObjectFixture.Product { Category = "Fizz" }));
        }
    }
}
