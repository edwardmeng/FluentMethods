namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ReferenceEquals()
        {
            string @this = null;
            bool result1 = @this.ReferenceEquals(null); // return true;
            bool result2 = @this.ReferenceEquals(""); // return false;
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}
