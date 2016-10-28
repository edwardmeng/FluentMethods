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
        public void AddRange()
        {
            // Type
            var @this = new List<string>();

            // Examples
            @this.AddRange("Fizz", "Buzz"); // Add "Fizz" and "Buzz" value

            // Unit Test
            Assert.True(@this.Contains("Fizz"));
            Assert.True(@this.Contains("Buzz"));
        }
    }
}
