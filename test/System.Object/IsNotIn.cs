namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNotIn()
        {
            string @this = "a";
            bool value1 = @this.IsNotIn("a", "1", "2", "3"); // return true;
            bool value2 = @this.IsNotIn("1", "2", "3"); // return false;
            Assert.False(value1);
            Assert.True(value2);
        }
    }
}
