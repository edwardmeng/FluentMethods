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
        public async Task AnyAsync()
        {
            var collection = (IEnumerable<char>)new[] { 'A', 'B', 'C', 'D' };
            Assert.True(await collection.AnyAsync(x => Task.Factory.StartNew(() => x < 'B')));
            Assert.False(await collection.AnyAsync(x => Task.Factory.StartNew(() => x < 'A')));
        }
    }
}
