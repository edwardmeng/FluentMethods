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
        public void Except()
        {
            var collection = (IEnumerable<Version>)new[]
            {
                new Version("0.0.1"),
                new Version("2.1.0"),
                new Version("1.2.0"),
            }; ;
            Assert.Equal(2, collection.Except(new[] { new Version("2.0.1") }, (x, y) => x.Major == y.Major).Count());
            Assert.Equal(3, collection.Except(new[] { new Version("3.0.1") }, (x, y) => x.Major == y.Major).Count());

            Assert.Equal(2, collection.Except(new[] { new Version("2.0.1") }, x => x.Major).Count());
            Assert.Equal(3, collection.Except(new[] { new Version("3.0.1") }, x => x.Major).Count());
        }
    }
}
