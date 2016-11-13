using System;
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
        public async Task UnorderedEqualAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.True(await collection.UnorderedEqualAsync(new[]
            {
                new Version("2.1.2"),
                new Version("1.2.2"),
                new Version("1.0.2"),
            }, (x, y) => Task.Factory.StartNew(() => x.Major == y.Major && x.Minor == y.Minor)));

            Assert.True(await collection.UnorderedEqualAsync(new[]
            {
                new Version("2.1.2"),
                new Version("1.2.2"),
                new Version("1.0.2"),
            }, x => Task.Factory.StartNew(() => new { x.Major, x.Minor })));
        }
    }
}
