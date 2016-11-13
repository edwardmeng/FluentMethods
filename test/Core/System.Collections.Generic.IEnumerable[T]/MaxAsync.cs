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
        public async Task Int32MaxAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(3, await collection.MaxAsync(x => Task.Factory.StartNew(() => x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task Int64MaxAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((long)3, await collection.MaxAsync(x => Task.Factory.StartNew(() => (long)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DoubleMaxAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((double)3, await collection.MaxAsync(x => Task.Factory.StartNew(() => (double)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task FloatMaxAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((float)3, await collection.MaxAsync(x => Task.Factory.StartNew(() => (float)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DecimalMaxAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((decimal)3, await collection.MaxAsync(x => Task.Factory.StartNew(() => (decimal)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task VersionMaxAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(new Version("3.0.0"), await collection.MaxAsync(x => Task.Factory.StartNew(() => x)));
        }
    }
}
