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
        public async Task AllAsync()
        {
            var collection = (IEnumerable<char>)new[] { 'A', 'B', 'C', 'D' };
            Assert.True(await collection.AllAsync(x => Task.Factory.StartNew(() => x < 'E')));
            Assert.False(await collection.AllAsync(x => Task.Factory.StartNew(() => x < 'B')));
        }
    }
}
