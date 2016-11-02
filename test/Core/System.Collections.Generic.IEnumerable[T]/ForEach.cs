using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ForEach()
        {
            var collection = (IEnumerable<string>)new[] { "A", "B", "C", "D" }; ;
            string result = null;
            int sum = 0;
            collection.ForEach(x => result += x.ToString());
            Assert.Equal("ABCD", result);
            collection.ForEach((x, i) => sum += i);
            Assert.Equal(6, sum);
        }
    }
}
