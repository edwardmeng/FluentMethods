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
        public void RemoveIf()
        {
            // Type
            var @this = new List<string> { "zA", "zB", "C" };

            // Exemples
            @this.RemoveIf("zA", @this.Contains); // Remove "zA" items

            // Unit Test
            Assert.Equal(2, @this.Count);
        }
    }
}
