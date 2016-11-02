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
        public void IsNotNullOrEmpty()
        {
            // Type
            string @thisValue = "Fizz";
            string @thisNull = null;

            // Examples
            bool value1 = @thisValue.IsNotNullOrEmpty(); // return true;
            bool value2 = @thisNull.IsNotNullOrEmpty(); // return false;

            // Unit Test
            Assert.True(value1);
            Assert.False(value2);
        }
    }
}
