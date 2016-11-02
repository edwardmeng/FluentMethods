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
        public void ToTitle()
        {
            // Type
            string @this = "fizz buzz";

            // Exemples
            string result = @this.ToTitle(); // return "Fizz Buzz";

            // Unit Test
            Assert.Equal("Fizz Buzz", result);
        }
    }
}
