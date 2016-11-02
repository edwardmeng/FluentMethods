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
        public void ToBoolean()
        {
            Assert.True("true".ToBoolean());
            Assert.False("false".ToBoolean());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToBoolean();
            });

            Assert.True("fizz".ToBoolean(true));
        }
    }
}
