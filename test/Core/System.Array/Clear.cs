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
        public void Clear()
        {
            Array @this = new[] { "Fizz", "Buzz" };
            @this.Clear(); // Remove all entries.
            Assert.Equal(null, @this.GetValue(0));
            Assert.Equal(null, @this.GetValue(1));
        }
    }
}
