using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentMethods.UnitTests
{
    public partial class EnumerableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Distinct()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("1.0.0"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(2, collection.Distinct((x, y) => x.Major == y.Major).Count());
            Assert.Equal(2, collection.Distinct(x => x.Major).Count());
        }
    }
}
