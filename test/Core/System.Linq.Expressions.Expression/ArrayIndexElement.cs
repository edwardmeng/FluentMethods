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
        public void ArrayIndexElement()
        {
            var parameter = Expression.Parameter(typeof(int[]), "array");
            var array = new[] { 1, 2, 3 };
            var expression = parameter.ArrayIndexElement(Expression.Constant(1));
            Assert.Equal(2, expression.ToLambda<Func<int[], int>>(parameter).Compile()(array));
        }
    }
}
