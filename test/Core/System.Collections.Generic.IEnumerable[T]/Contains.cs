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
        public void Contains()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.True(collection.Contains(new Version("2.0.1"),(x,y)=>x.Major == y.Major));
            Assert.False(collection.Contains(new Version("3.0.1"), (x, y) => x.Major == y.Major));

            Assert.True(collection.Contains(new Version("2.0.1"), x => x.Major));
            Assert.False(collection.Contains(new Version("3.0.1"), x => x.Major));
        }
    }
}
