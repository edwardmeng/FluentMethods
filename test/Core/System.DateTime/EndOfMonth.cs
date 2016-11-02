using System;

namespace FluentMethods.UnitTests
{
    public partial class DateTimeFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void EndOfMonth()
        {
            var @this = new DateTime(2013, 12, 22);
            DateTime value = @this.EndOfMonth(); // value = "2013/12/31 23:59:59:999";
            Assert.Equal(new DateTime(2013, 12, 31, 23, 59, 59, 999), value);
        }
    }
}
