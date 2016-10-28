using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class DictionaryFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetOrAdd()
        {
            var dictionary = new Dictionary<string, string> { { "Fizz", "Fizz" } };
            Assert.Equal("Fizz", dictionary.GetOrAdd("Fizz","Buzz"));
            Assert.Equal(1,dictionary.Count);
            Assert.Equal("Buzz", dictionary.GetOrAdd("Buzz", "Buzz"));
            Assert.Equal(2, dictionary.Count);
        }
    }
}
