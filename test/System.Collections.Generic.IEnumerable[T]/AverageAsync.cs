using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task Int32AverageAsync()
        {
            var collection = (IEnumerable<int>)new[] { 1, 2, 3, 4 };
            Assert.Equal(5, await collection.AverageAsync(x => Task.FromResult(x * 2)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task Int64AverageAsync()
        {
            var collection = (IEnumerable<long>)new[] { 1L, 2, 3, 4 };
            Assert.Equal(5, await collection.AverageAsync(x => Task.FromResult(x * 2)));
        }
    }
}
