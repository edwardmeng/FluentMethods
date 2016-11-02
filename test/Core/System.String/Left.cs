namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Left()
        {
            // Type
            string @this = "Fizz";

            // Examples
            string result1 = @this.Left(2); // return "Fi";
            string result2 = @this.Left(int.MaxValue); // return "Fizz";

            // Unit Test
            Assert.Equal("Fi", result1);
            Assert.Equal("Fizz", result2);
        }
    }
}
