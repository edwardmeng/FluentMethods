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
        public void AddRangeIf()
        {
            // Type
            var @this = new List<string> { "FizzExisting" };

            // Examples
            @this.AddRangeIf(x => !@this.Contains(x), "Fizz"); // Add "Fizz" value
            @this.AddRangeIf(x => !@this.Contains(x), "FizzExisting", "Buzz"); // Add "Buzz" value but doesn't add "FizzExisting"

            // Unit Test
            Assert.Equal(3, @this.Count);
        }
    }
}
