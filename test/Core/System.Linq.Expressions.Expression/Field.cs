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
            var parameter = Expression.Parameter(typeof(Product), "x");
            var expression = parameter.Field("Category");
            var lambda = expression.ToLambda<Func<Product, string>>(parameter).Compile();
            Assert.Equal("Fizz", lambda(new Product { Category = "Fizz" }));
        }
    }
}
