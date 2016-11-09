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
        public void Throw()
        {
            Assert.Throws<NotSupportedException>(() => Expression.New(typeof(NotSupportedException)).Throw().ToLambda<Action>().Compile()());
        }
    }
}
