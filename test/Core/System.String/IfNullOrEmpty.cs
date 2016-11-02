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
        public void IfNullOrEmpty()
        {
            string @this = "";
            string result = @this.IfNullOrEmpty("FizzBuzz"); // return "FizzBuzz";
            Assert.Equal("FizzBuzz", result);

            @this = null;
            result = @this.IfNullOrEmpty("FizzBuzz"); // return "FizzBuzz";
            Assert.Equal("FizzBuzz", result);
        }
    }
}
