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
        public void IsDateTime()
        {
            Assert.True("2016/10/27".IsDateTime());
            Assert.False("fizz".IsDateTime());
        }
    }
}
