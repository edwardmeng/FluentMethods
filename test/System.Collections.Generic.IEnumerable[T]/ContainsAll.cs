using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ContainsAll()
        {
            var collection = (IEnumerable<string>) new[] {"A", "B", "C", "D"};
            Assert.True(collection.ContainsAll("A", "B"));
            Assert.False(collection.ContainsAll("E", "B"));
        }
    }
}
