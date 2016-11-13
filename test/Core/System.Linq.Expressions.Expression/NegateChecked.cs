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
        public void NegateChecked()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            Assert.Equal(-3, parameter.NegateChecked().ToLambda<Func<int, int>>(parameter).Compile()(3));
        }
    }
}
