namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Nbsp2Ws()
        {
            Assert.Equal("Fizz\t Buzz", "Fizz&nbsp;&nbsp;&#160;&nbsp;&nbsp;Buzz".Nbsp2Ws());
            Assert.Equal("Fizz Buzz", "Fizz&nbsp;Buzz".Nbsp2Ws());
        }
    }
}
