using System.Reflection;

namespace FluentMethods.UnitTests
{
    public partial class EnumFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void HasFlag()
        {
            var flag = BindingFlags.Public | BindingFlags.Instance;
            Assert.True(flag.HasFlag(BindingFlags.Instance));
            Assert.False(flag.HasFlag(BindingFlags.NonPublic));
        }
    }
}
