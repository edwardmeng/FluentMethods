namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNumber()
        {
            Assert.True("20.5".IsNumber());
            Assert.True("2.05e10".IsNumber());
            Assert.False("fizz".IsNumber());
        }
    }
}
