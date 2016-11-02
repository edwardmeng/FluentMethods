using System;
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
        public void AsReadOnly()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string> { { "Fizz", "Fizz" } };
            dictionary = dictionary.AsReadOnly();
            Assert.Throws<NotSupportedException>(()=> dictionary.Add("Buzz","Buzz"));
        }
    }
}
