namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsDefault()
        {
            int intDefault = 0;
            int intNotDefault = 1;
            bool result1 = intDefault.IsDefault(); // return true;
            bool result2 = intNotDefault.IsDefault(); // return false;
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}
