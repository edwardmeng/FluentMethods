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
        public void EndOfYear()
        {
            var @this = new DateTime(2013, 04, 13);
            DateTime value = @this.EndOfYear(); // value = "2013/12/31 23:59:59:999";
            Assert.Equal(new DateTime(2013, 12, 31, 23, 59, 59, 999), value);
        }
    }
}
