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
        public void BitwiseXor()
        {
            var expression = Expression.Constant(3).Xor(Expression.Constant(6));
            Assert.Equal(5, expression.ToLambda<Func<int>>().Compile()());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LogicXor()
        {
            var expression = Expression.Constant(true).Xor(Expression.Constant(false));
            Assert.Equal(true, expression.ToLambda<Func<bool>>().Compile()());
        }
    }
}
