using System;
using System.Linq;

namespace FluentMethods.UnitTests
{
    public partial class QueryableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void OrderBy()
        {
            var array = new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            };
            array = array.AsQueryable().OrderBy("Major asc, Minor desc").ToArray();
            Assert.Equal(new Version("1.2.0"), array[0]);
            Assert.Equal(new Version("1.0.0"), array[1]);
            Assert.Equal(new Version("2.1.0"), array[2]);
        }
    }
}
