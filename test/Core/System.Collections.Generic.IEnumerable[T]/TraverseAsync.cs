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
        public async Task TraverseAsync()
        {
            var collection = (IEnumerable<TraverseItem>)new[] { new TraverseItem { Value = 1, Children = new[] { new TraverseItem { Value = 2 }, new TraverseItem() { Value = 3 } } }, new TraverseItem { Value = 4 }, }; ;
            int sum = 0;
            await collection.TraverseAsync(x => Task.FromResult(x.Children), x => sum += x.Value);
            Assert.Equal(10, sum);
        }
    }
}
