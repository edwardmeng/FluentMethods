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
        public void Right()
        {
            // Type
            string @this = "Fizz";

            // Examples
            string result1 = @this.Right(2); // return "zz";
            string result2 = @this.Right(int.MaxValue); // return "Fizz";

            // Unit Test
            Assert.Equal("zz", result1);
            Assert.Equal("Fizz", result2);
        }
    }
}
