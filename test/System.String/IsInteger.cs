namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsInteger()
        {
            Assert.True("20".IsInteger());
            Assert.False("20.5".IsInteger());
            Assert.False("fizz".IsInteger());
        }
    }
}
