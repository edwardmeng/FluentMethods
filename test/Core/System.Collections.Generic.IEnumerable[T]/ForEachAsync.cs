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
        public async Task ForEachAsync()
        {
            var collection = (IEnumerable<string>)new[] { "A", "B", "C", "D" }; ;
            string result = null;
            int sum = 0;
            await collection.ForEachAsync(x =>
            {
                result += x.ToString();
                return Task.Factory.StartNew(() => { });
            });
            Assert.Equal("ABCD", result);
            await collection.ForEachAsync((x, i) =>
            {
                sum += i;
                return Task.Factory.StartNew(() => { });
            });
            Assert.Equal(6, sum);
        }
    }
}
