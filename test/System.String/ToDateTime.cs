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
        public void ToDateTime()
        {
            Assert.Equal(new DateTime(2016,10,27),"2016/10/27".ToDateTime());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToDateTime();
            });

            Assert.Equal(new DateTime(2016, 10, 27), "fizz".ToDateTime(new DateTime(2016, 10, 27)));
        }
    }
}
