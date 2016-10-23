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
        public void FormatWith()
        {
            string @this = "{0}{1}";
            string value = @this.FormatWith("Fizz", "Buzz"); // return "FizzBuzz";
            Assert.Equal("FizzBuzz", value);
        }
    }
}
