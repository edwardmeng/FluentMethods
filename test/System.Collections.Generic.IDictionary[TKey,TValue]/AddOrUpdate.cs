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
        public void AddOrUpdate()
        {
            var dictionary = new Dictionary<string,string>();
            dictionary.AddOrUpdate("Key","Fizz");
            Assert.Equal("Fizz",dictionary["Key"]);
            dictionary.AddOrUpdate("Key", "Buzz");
            Assert.Equal("Buzz", dictionary["Key"]);
        }
    }
}
