using System;
using System.Collections;
using System.Linq;
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
        public void ToValueType()
        {
            var parameter = Expression.Parameter(typeof(object), "x");
            Assert.Equal(35, parameter.To<int>().ToLambda<Func<object, int>>(parameter).Compile()(35));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToNullable()
        {
            var parameter = Expression.Parameter(typeof(object), "x");
            var lambda = parameter.To<int?>().ToLambda<Func<object, int?>>(parameter).Compile();
            Assert.Equal(35,lambda(35));
            Assert.Null(lambda(null));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToObject()
        {
            var parameter = Expression.Parameter(typeof(int?), "x");
            var lambda = parameter.To<object>().ToLambda<Func<int?, object>>(parameter).Compile();
            Assert.Equal(35, lambda(35));
            Assert.Null(lambda(null));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToInterface()
        {
            var parameter = Expression.Parameter(typeof(Array), "x");
            var lambda = parameter.To<IEnumerable>().ToLambda<Func<Array, IEnumerable>>(parameter).Compile();
            var result = lambda(new[] {"Fizz", "Buzz"}).OfType<string>().ToArray();
            Assert.Equal(2, result.Length);
            Assert.Equal("Fizz", result[0]);
            Assert.Equal("Buzz", result[1]);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void To()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var lambda = parameter.To<decimal>().ToLambda<Func<int, decimal>>(parameter).Compile();
            Assert.Equal(35, lambda(35));
        }
    }
}
