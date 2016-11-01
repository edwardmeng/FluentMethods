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
        public void ForEachAsync()
        {
            var collection = (IEnumerable<string>)new[] { "A", "B", "C", "D" }; ;
            string result = null;
            int sum = 0;
            collection.ForEachAsync(x =>
            {
                result += x.ToString();
                return Task.Delay(0);
            });
            Assert.Equal("ABCD", result);
            collection.ForEachAsync((x, i) =>
            {
                sum += i;
                return Task.Delay(0);
            });
            Assert.Equal(6, sum);
        }
    }
}
