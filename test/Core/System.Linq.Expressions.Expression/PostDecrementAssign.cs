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
        public void PostDecrementAssign()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            Assert.Equal(3, Expression.Block(parameter.PostDecrementAssign()).ToLambda<Func<int, int>>(parameter).Compile()(3));
            Assert.Equal(2, Expression.Block(parameter.PostDecrementAssign(), parameter).ToLambda<Func<int, int>>(parameter).Compile()(3));
        }
    }
}
