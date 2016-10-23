using System;

namespace FluentMethods.UnitTests
{
    public partial class BooleanFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToString()
        {
            bool @thisTrue = true;
            bool @thisFalse = false;
            string result1 = @thisTrue.ToString("Fizz", "Buzz"); // return "Fizz";
            string result2 = @thisFalse.ToString("Fizz", "Buzz"); // return "Buzz";
            Assert.Equal("Fizz", result1);
            Assert.Equal("Buzz", result2);
        }
    }
}
