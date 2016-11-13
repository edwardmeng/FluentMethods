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
        public async Task Int32SumAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(6, await collection.SumAsync(x => Task.Factory.StartNew(() => x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task Int64SumAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((long)6, await collection.SumAsync(x => Task.Factory.StartNew(() => (long)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DoubleSumAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((double)6, await collection.SumAsync(x => Task.Factory.StartNew(() => (double)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task FloatSumAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((float)6, await collection.SumAsync(x => Task.Factory.StartNew(() => (float)x.Major)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DecimalSumAsync()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("3.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal((decimal)6, await collection.SumAsync(x => Task.Factory.StartNew(() => (decimal)x.Major)));
        }
    }
}
