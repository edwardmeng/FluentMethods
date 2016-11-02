namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNotNull()
        {
            object @thisNull = null;
            var @thisNotNull = new object();
            bool value1 = @thisNull.IsNotNull(); // return false;
            bool value2 = @thisNotNull.IsNotNull(); // return true;
            Assert.False(value1);
            Assert.True(value2);
        }
    }
}
