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
        public void Reverse()
        {
            // Type
            string @this = "FizzBuzz";

            // Examples
            string value = @this.Reverse(); // return "zzuBzziF";

            // Unit Test
            Assert.Equal("zzuBzziF", value);
        }
    }
}
