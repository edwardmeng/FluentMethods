using System;
using System.Collections.Generic;
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
        public void ListInitElementInit()
        {
            var addMethod = typeof(List<int>).GetMethod("Add");
            var lambda = Expression.New(typeof(List<int>)).ListInit(
                    Expression.ElementInit(addMethod, Expression.Constant(2)),
                    Expression.ElementInit(addMethod, Expression.Constant(4)))
                .ToLambda<Func<List<int>>>().Compile();
            var list = lambda();
            Assert.Equal(2, list.Count);
            Assert.Equal(2, list[0]);
            Assert.Equal(4, list[1]);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ListInitExpression()
        {
            var lambda = Expression.New(typeof(List<int>)).ListInit(Expression.Constant(2), Expression.Constant(4)).ToLambda<Func<List<int>>>().Compile();
            var list = lambda();
            Assert.Equal(2, list.Count);
            Assert.Equal(2, list[0]);
            Assert.Equal(4, list[1]);
        }
    }
}
