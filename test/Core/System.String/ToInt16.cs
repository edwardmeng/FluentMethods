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
        public void ToInt16()
        {
            Assert.Equal((short)20, "20".ToInt16());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToInt16();
            });

            Assert.Equal((short)20, "fizz".ToInt16(20));
        }
    }
}
