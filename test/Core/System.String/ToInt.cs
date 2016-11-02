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
        public void ToInt()
        {
            Assert.Equal(20, "20".ToInt());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToInt();
            });

            Assert.Equal(20, "fizz".ToInt(20));
        }
    }
}
