using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class CollectionFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void RemoveRangeIf()
        {
            // Type
            var @this = new List<string> { "zA", "zB", "C" };

            // Exemples
            @this.RemoveRangeIf(x => x.StartsWith("z"), "zA", "zB", "C"); // Remove all items starting by "z"

            // Unit Test
            Assert.Equal(1, @this.Count);
        }
    }
}
