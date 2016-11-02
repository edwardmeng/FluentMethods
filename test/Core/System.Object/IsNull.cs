namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNull()
        {
            object @thisNull = null;
            var @thisNotNull = new object();
            bool value1 = @thisNull.IsNull(); // return true;
            bool value2 = @thisNotNull.IsNull(); // return false;
            Assert.True(value1);
            Assert.False(value2);
        }
    }
}
