using System;

namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToInt64()
        {
            Assert.Equal((long)20, "20".ToInt64());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToInt64();
            });

            Assert.Equal((long)20, "fizz".ToInt64(20));
        }
    }
}
