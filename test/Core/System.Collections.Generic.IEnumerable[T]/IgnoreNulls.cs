using System.Collections.Generic;
using System.Linq;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IgnoreNulls()
        {
            var collection = (IEnumerable<string>)new[] { "A", null, "C", "D" };
            var array = collection.IgnoreNulls().ToArray();
            Assert.Equal(3, array.Length);
        }
    }
}
