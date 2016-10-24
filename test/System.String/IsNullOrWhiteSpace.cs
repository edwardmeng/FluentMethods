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
        public void IsNullOrWhiteSpace()
        {
            // Type
            string @thisNull = null;

            // Examples
            bool value1 = "  Z".IsNullOrWhiteSpace(); // return true;
            bool value2 = @thisNull.IsNullOrWhiteSpace(); // return false;
            bool value3 = "".IsNullOrWhiteSpace(); // return false;
            bool value4 = "   ".IsNullOrWhiteSpace(); // return false;

            // Unit Test
            Assert.False(value1);
            Assert.True(value2);
            Assert.True(value3);
            Assert.True(value4);
        }
    }
}
