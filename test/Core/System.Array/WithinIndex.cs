using System;

namespace FluentMethods.UnitTests
{
    public partial class ArrayFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void WithinIndex()
        {
            Array array = new[] { "Fizz", "Buzz" };
            Assert.True(array.WithinIndex(1));
            Assert.False(array.WithinIndex(2));
        }
    }
}
