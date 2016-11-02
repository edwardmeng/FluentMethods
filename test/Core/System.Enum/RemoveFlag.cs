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
        public void RemoveFlag()
        {
            var flag = BindingFlags.Public | BindingFlags.Instance;
            var result = flag.RemoveFlag(BindingFlags.Instance);
            Assert.Equal(BindingFlags.Public, result);
        }
    }
}
