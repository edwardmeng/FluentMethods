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
        public void IsEmpty()
        {
            Guid guidEmpty = Guid.Empty;
            Guid guidValue = Guid.NewGuid();
            Assert.True(guidEmpty.IsEmpty());
            Assert.False(guidValue.IsEmpty());
        }
    }
}
