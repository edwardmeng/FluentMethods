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
        public void RemoveRange()
        {
            // Type
            var @this = new List<string> { "zA", "zB", "C" };

            // Exemples
            @this.RemoveRange("zA", "zB"); // Remove "zA" and "zB" items

            // Unit Test
            Assert.Equal(1, @this.Count);
        }
    }
}
