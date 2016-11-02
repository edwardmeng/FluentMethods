namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsIn()
        {
            string @this = "a";
            bool value1 = @this.IsIn("a", "1", "2", "3"); // return true;
            bool value2 = @this.IsIn("1", "2", "3"); // return false;
            Assert.True(value1);
            Assert.False(value2);
        }
    }
}
