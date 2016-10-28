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
        public void AddRangeIfNotContains()
        {
            // Type
            var @this = new List<string> { "FizzExisting" };

            // Examples
            @this.AddRangeIfNotContains("Fizz"); // Add "Fizz" value
            @this.AddRangeIfNotContains("FizzExisting", "Buzz"); // Add "Buzz" value but doesn't add "Fizz"

            // Unit Test
            Assert.Equal(3, @this.Count);
        }
    }
}
