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
        public async Task ContainsAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.True(await collection.ContainsAsync(new Version("2.0.1"), (x, y) => Task.Factory.StartNew(() => x.Major == y.Major)));
            Assert.False(await collection.ContainsAsync(new Version("3.0.1"), (x, y) => Task.Factory.StartNew(() => x.Major == y.Major)));

            Assert.True(await collection.ContainsAsync(new Version("2.0.1"), x => Task.Factory.StartNew(() => x.Major)));
            Assert.False(await collection.ContainsAsync(new Version("3.0.1"), x => Task.Factory.StartNew(() => x.Major)));
        }
    }
}
