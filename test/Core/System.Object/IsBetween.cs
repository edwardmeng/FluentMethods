namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsBetween()
        {
            int @this = 3;
            bool result1 = @this.IsBetween(1, 4); // return true;
            bool result2 = @this.IsBetween(1, 3); // return false;
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}
