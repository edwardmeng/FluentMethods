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
        public void IsNullOrEmpty()
        {
            string @thisValue = "Fizz";
            string @thisNull = null;

            bool value1 = @thisValue.IsNullOrEmpty(); // return false;
            bool value2 = @thisNull.IsNullOrEmpty(); // return true;

            Assert.False(value1);
            Assert.True(value2);
        }
    }
}
