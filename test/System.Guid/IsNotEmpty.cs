using System;

namespace FluentMethods.UnitTests
{
    public partial class GuidFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsNotEmpty()
        {
            Guid guidEmpty = Guid.Empty;
            Guid guidValue = Guid.NewGuid();
            Assert.False(guidEmpty.IsNotEmpty());
            Assert.True(guidValue.IsNotEmpty());
        }
    }
}
