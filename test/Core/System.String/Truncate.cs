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
        public void Truncate()
        {
            // Type
            string @this = "123456789";

            // Exemples
            string result = @this.Truncate(6); // return "123...";

            // Unit Test
            Assert.Equal("123...", result);
        }
    }
}
