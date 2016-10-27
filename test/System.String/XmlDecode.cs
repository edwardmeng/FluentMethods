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
        public void XmlDecode()
        {
            Assert.Equal("<node>Fizz&Buzz</node>", "&lt;node&gt;Fizz&amp;Buzz&lt;/node&gt;".XmlDecode());
        }
    }
}
