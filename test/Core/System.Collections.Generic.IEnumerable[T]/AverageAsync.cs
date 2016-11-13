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
            Assert.Equal((double)5, await collection.AverageAsync(x => Task.Factory.StartNew(() => x * 2)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task Int64AverageAsync()
        {
            var collection = (IEnumerable<long>)new[] { 1L, 2, 3, 4 };
            Assert.Equal((double)5, await collection.AverageAsync(x => Task.Factory.StartNew(() => x * 2)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task FloatAverageAsync()
        {
            var collection = (IEnumerable<float>)new[] { 1.5f, 2.5f, 3.5f, 4.5f };
            Assert.Equal((float)6, await collection.AverageAsync(x => Task.Factory.StartNew(() => x * 2)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DoubleAverageAsync()
        {
            var collection = (IEnumerable<double>)new[] { 1.5d, 2.5d, 3.5d, 4.5d };
            Assert.Equal((double)6, await collection.AverageAsync(x => Task.Factory.StartNew(() => x * 2)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task DecimalAverageAsync()
        {
            var collection = (IEnumerable<decimal>)new[] { (decimal)1.5, (decimal)2.5, (decimal)3.5, (decimal)4.5 };
            Assert.Equal((decimal)6, await collection.AverageAsync(x => Task.Factory.StartNew(() => x * 2)));
        }
    }
}
