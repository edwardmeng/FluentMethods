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
        public void ArrayLength()
        {
            var parameter = Expression.Parameter(typeof(int[]), "array");
            var array = new[] { 1, 2, 3 };
            var expression = parameter.ArrayLength();
            Assert.Equal(3, expression.ToLambda<Func<int[], int>>(parameter).Compile()(array));
        }
    }
}
