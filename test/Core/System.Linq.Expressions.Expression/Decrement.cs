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
        public void Decrement()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            Assert.Equal(2, Expression.Block(parameter.Decrement()).ToLambda<Func<int,int>>(parameter).Compile()(3));
            Assert.Equal(3, Expression.Block(parameter.Decrement(), parameter).ToLambda<Func<int, int>>(parameter).Compile()(3));
        }
    }
}
