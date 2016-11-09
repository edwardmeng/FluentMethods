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
        public void Power()
        {
            var expression = Expression.Constant((double)2).Power(Expression.Constant((double)3));
            Assert.Equal(8, expression.ToLambda<Func<double>>().Compile()());
        }
    }
}
