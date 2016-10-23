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
        public void Br2Nl()
        {
            string @this = "Fizz<br />Buzz";
            string result = @this.Br2Nl(); // return "Fizz/r/nBuzz";
            Assert.Equal("Fizz" + Environment.NewLine + "Buzz", result);
        }
    }
}
