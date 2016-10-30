namespace FluentMethods.UnitTests
{
    public class TypeFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNullable()
        {
            Assert.True(typeof(int?).IsNullable());
            Assert.False(typeof(int).IsNullable());
            Assert.True(typeof(string).IsNullable());
        }
    }
}
