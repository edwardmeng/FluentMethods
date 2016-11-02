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
        public void Flatten()
        {
            var collection = (IEnumerable<IEnumerable<string>>)new IEnumerable<string>[] { new []{ "A", "B" }, new []{ "C", "D" } };
            var array = collection.Flatten().ToArray();
            Assert.Equal(4, array.Length);
        }
    }
}
