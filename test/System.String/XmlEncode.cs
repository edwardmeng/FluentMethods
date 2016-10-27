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
        public void XmlEncode()
        {
            Assert.Equal("&lt;node&gt;Fizz&amp;Buzz&lt;/node&gt;", "<node>Fizz&Buzz</node>".XmlEncode());
        }
    }
}
