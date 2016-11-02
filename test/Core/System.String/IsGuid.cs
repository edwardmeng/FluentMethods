using System;

namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsGuid()
        {
            Assert.True(Guid.NewGuid().ToString().IsGuid());
            Assert.False("fizz".IsGuid());
        }
    }
}
