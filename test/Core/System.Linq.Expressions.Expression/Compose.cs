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
        public void Compose()
        {
            Expression<Func<double>> left = () => 2;
            Expression<Func<double>> right = () => 3;
            Assert.Equal(8, left.Compose(right, Expression.Power).Compile()());
        }
    }
}
