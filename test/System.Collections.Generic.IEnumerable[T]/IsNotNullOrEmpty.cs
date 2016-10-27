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
        public void IsNotNullOrEmpty()
        {
            Assert.False(((IEnumerable<string>)null).IsNotNullOrEmpty());
            Assert.False(new string[0].IsNotNullOrEmpty());
            Assert.True(new[] { "A" }.IsNotNullOrEmpty());
        }
    }
}
