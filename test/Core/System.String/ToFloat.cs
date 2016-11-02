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
        public void ToFloat()
        {
            Assert.Equal((float)20.5, "20.5".ToFloat());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToFloat();
            });

            Assert.Equal((float)20.5, "fizz".ToFloat((float)20.5));
        }
    }
}
