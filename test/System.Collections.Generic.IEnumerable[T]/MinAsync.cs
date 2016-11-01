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
        public async Task Int32MinAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(1, await collection.MinAsync(x => Task.FromResult(x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task Int64MinAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(1, await collection.MinAsync(x => Task.FromResult((long)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DoubleMinAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(1, await collection.MinAsync(x => Task.FromResult((double)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task FloatMinAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(1, await collection.MinAsync(x => Task.FromResult((float)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DecimalMinAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(1, await collection.MinAsync(x => Task.FromResult((decimal)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task VersionMinAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(new Version("1.2.0"), await collection.MinAsync(x => Task.FromResult(x)));
        }
    }
}
