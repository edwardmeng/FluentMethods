using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
        private class TraverseItem
        {
            public int Value { get; set; }

            public IEnumerable<TraverseItem> Children { get; set; }
        }
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Traverse()
        {
            var collection = (IEnumerable<TraverseItem>)new[] { new TraverseItem { Value = 1, Children = new[] { new TraverseItem { Value = 2 }, new TraverseItem() { Value = 3 } } }, new TraverseItem { Value = 4 }, }; ;
            int sum = 0;
            collection.Traverse(x => x.Children, x => sum += x.Value);
            Assert.Equal(10, sum);
        }
    }
}
