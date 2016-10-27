using System.Linq;
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
        public void GetEnumMembers()
        {
            var flag = BindingFlags.Public | BindingFlags.Instance;
            var result = flag.GetEnumMembers().ToArray();
            Assert.Equal(2, result.Length);
        }
    }
}
