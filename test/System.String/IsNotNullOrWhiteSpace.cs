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
        public void IsNotNullOrWhiteSpace()
        {
            // Type
            string @thisNull = null;

            // Examples
            bool value1 = "  Z".IsNotNullOrWhiteSpace(); // return true;
            bool value2 = @thisNull.IsNotNullOrWhiteSpace(); // return false;
            bool value3 = "".IsNotNullOrWhiteSpace(); // return false;
            bool value4 = "   ".IsNotNullOrWhiteSpace(); // return false;

            // Unit Test
            Assert.True(value1);
            Assert.False(value2);
            Assert.False(value3);
            Assert.False(value4);
        }
    }
}
