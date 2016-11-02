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
        public void AddFlag()
        {
            var flag = BindingFlags.Public;
            var result = flag.AddFlag(BindingFlags.Instance);
            Assert.Equal(BindingFlags.Public|BindingFlags.Instance, result);
        }
    }
}
