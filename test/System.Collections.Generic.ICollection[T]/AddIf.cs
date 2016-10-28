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
        public void AddIf()
        {
            // Type
            var @this = new List<string>();

            // Examples
            @this.AddIf(s => true, "Fizz"); // Add "Fizz" value
            @this.AddIf(s => false, "Buzz"); // Doesn't add "Buzz" value

            // Unit Test
            Assert.True(@this.Contains("Fizz"));
            Assert.False(@this.Contains("Buzz"));
        }
    }
}
