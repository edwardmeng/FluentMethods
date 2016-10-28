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
        public void AddIfNotContains()
        {
            // Type
            var @this = new List<string> { "FizzExisting" };

            // Examples
            @this.AddIfNotContains("Fizz"); // Add "Fizz" value
            @this.AddIfNotContains("FizzExisting"); // Doesn't add "FizzExisting" value, the Collection already contains it.

            // Unit Test
            Assert.Equal(2, @this.Count);
        }
    }
}
