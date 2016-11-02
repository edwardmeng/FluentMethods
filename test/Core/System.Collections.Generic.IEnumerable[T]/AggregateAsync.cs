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
        public async Task AggregateAsync()
        {
            var collection = (IEnumerable<string>)new[] { "A", "B", "C", "D" };
            Assert.Equal("0xabcd", await collection.AggregateAsync("0x", (s, x) => Task.FromResult(s + x.ToLower())));
        }
    }
}
