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
        public void ToDecimal()
        {
            Assert.Equal((decimal)20.5, "20.5".ToDecimal());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToDecimal();
            });

            Assert.Equal((decimal)20.5, "fizz".ToDecimal((decimal)20.5));
        }
    }
}
