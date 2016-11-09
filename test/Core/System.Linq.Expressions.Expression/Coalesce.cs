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
        public void Coalesce()
        {
            var parameter = Expression.Parameter(typeof(string), "x");
            var expression = parameter.Coalesce(Expression.Constant("Buzz"));
            var lambda = expression.ToLambda<Func<string, string>>(parameter).Compile();
            Assert.Equal("Fizz", lambda("Fizz"));
            Assert.Equal("Buzz", lambda(null));
        }
    }
}
