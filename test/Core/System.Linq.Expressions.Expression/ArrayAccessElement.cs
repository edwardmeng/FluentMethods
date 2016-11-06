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
        public void ArrayAccessElement()
        {
            var parameter = Expression.Parameter(typeof(int[]), "array");
            var array = new[] { 1, 2, 3 };
            var expression = Expression.Assign(parameter.ArrayAccessElement(Expression.Constant(1)),Expression.Constant(256));
            expression.ToLambda<Action<int[]>>(parameter).Compile()(array);
            Assert.Equal(256, array[1]);
        }
    }
}
