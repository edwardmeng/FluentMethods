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
        public void RemoveAll()
        {
            // Type
            var @this = new List<string> { "zA", "zB", "C" };

            // Exemples
            @this.RemoveAll(x => x.StartsWith("z")); // Remove all items starting by "z"

            // Unit Test
            Assert.Equal(1, @this.Count);
        }
    }
}
