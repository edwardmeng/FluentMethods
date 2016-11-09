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
        public void PostIncrementAssign()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            Assert.Equal(3, Expression.Block(parameter.PostIncrementAssign()).ToLambda<Func<int, int>>(parameter).Compile()(3));
            Assert.Equal(4, Expression.Block(parameter.PostIncrementAssign(), parameter).ToLambda<Func<int, int>>(parameter).Compile()(3));
        }
    }
}
