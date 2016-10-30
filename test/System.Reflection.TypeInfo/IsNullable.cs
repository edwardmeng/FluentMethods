using System.Reflection;

namespace FluentMethods.UnitTests
{
    public class TypeInfoFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNullable()
        {
            Assert.True(typeof(int?).GetTypeInfo().IsNullable());
            Assert.False(typeof(int).GetTypeInfo().IsNullable());
            Assert.True(typeof(string).GetTypeInfo().IsNullable());
        }
    }
}
