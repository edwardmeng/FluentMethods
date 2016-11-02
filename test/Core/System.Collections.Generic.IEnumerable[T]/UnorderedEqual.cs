using System;
using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UnorderedEqual()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.True(collection.UnorderedEqual(new[]
            {
                new Version("2.1.2"),
                new Version("1.2.2"),
                new Version("1.0.2"),
            }, (x, y) => x.Major == y.Major && x.Minor == y.Minor));

            Assert.True(collection.UnorderedEqual(new[]
            {
                new Version("2.1.2"),
                new Version("1.2.2"),
                new Version("1.0.2"),
            }, x => new { x.Major, x.Minor }));
        }
    }
}
