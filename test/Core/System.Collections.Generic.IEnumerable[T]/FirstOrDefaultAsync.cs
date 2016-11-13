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
        public async Task FirstOrDefaultAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            };

            Assert.Equal(new Version("2.1.0"), await collection.FirstOrDefaultAsync(x => Task.Factory.StartNew(() => x.Major == 2)));
            Assert.Null(await collection.FirstOrDefaultAsync(x => Task.Factory.StartNew(() => x.Major == 3)));
        }
    }
}
