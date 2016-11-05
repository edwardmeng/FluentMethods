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
        public void Modulo()
        {
            var expression = Expression.Constant(19).Modulo(Expression.Constant(7));
            Assert.Equal(5, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
