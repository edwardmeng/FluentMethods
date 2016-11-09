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
        public void MemberProperty()
        {
            var parameter = Expression.Parameter(typeof(ObjectFixture.Product), "x");
            var expression = parameter.Member("Title");
            var lambda = expression.ToLambda<Func<ObjectFixture.Product, string>>(parameter).Compile();
            Assert.Equal("Fizz", lambda(new ObjectFixture.Product { Title = "Fizz" }));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MemberField()
        {
            var parameter = Expression.Parameter(typeof(ObjectFixture.Product), "x");
            var expression = parameter.Member("Category");
            var lambda = expression.ToLambda<Func<ObjectFixture.Product, string>>(parameter).Compile();
            Assert.Equal("Fizz", lambda(new ObjectFixture.Product { Category = "Fizz" }));
        }
    }
}
