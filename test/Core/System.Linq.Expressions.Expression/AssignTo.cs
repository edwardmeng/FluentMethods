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
        public void AssignTo()
        {
            var left = Expression.Variable(typeof(int));
            var right = Expression.Variable(typeof(int));
            var expression = Expression.Block(new[] { left, right },
                Expression.Assign(left, Expression.Constant(5)),
                left.AssignTo(right),
                right);

            Assert.Equal(5, expression.ToLambda<Func<int>>().Compile()());
        }
    }
}
