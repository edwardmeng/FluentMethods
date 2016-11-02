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
        public void IsBool()
        {
            Assert.True("true".IsBoolean());
            Assert.True("false".IsBoolean());
            Assert.False("fizz".IsBoolean());
        }
    }
}
