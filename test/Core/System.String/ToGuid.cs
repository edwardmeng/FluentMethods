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
        public void ToGuid()
        {
            var guid = Guid.NewGuid();
            Assert.Equal(guid, guid.ToString().ToGuid());

            Assert.Throws<FormatException>(() =>
            {
                var value = "fizz".ToGuid();
            });

            Assert.Equal(guid, "fizz".ToGuid(guid));
        }
    }
}
