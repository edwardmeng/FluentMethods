using System;
using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class ListFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AsReadOnly()
        {
            IList<string> list = new List<string> { "Fizz" };
            list = list.AsReadOnly();
            Assert.Throws<NotSupportedException>(()=> list.Add("Buzz"));
        }
    }
}
