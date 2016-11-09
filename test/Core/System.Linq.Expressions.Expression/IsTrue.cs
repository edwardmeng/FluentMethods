﻿using System;
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
        public void IsTrue()
        {
            var parameter = Expression.Parameter(typeof(bool), "x");
            var expression = parameter.IsTrue();
            var lambda = expression.ToLambda<Func<bool, bool>>(parameter).Compile();
            Assert.False(lambda(false));
            Assert.True(lambda(true));
        }
    }
}
