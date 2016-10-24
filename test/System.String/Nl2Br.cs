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
        public void Nl2Br()
        {
            // Type
            string @this = "Fizz" + Environment.NewLine + "Buzz";

            // Exemples
            string result = @this.Nl2Br(); // return "Fizz<br />Buzz";

            // Unit Test
            Assert.Equal("Fizz<br />Buzz", result);
        }
    }
}
