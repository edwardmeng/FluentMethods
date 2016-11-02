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
        public void EndOfDay()
        {
            DateTime @this = DateTime.Now;
            DateTime value = @this.EndOfDay(); // value = "yyyy/MM/dd 23:59:59:999";
            Assert.Equal(new DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 999), value);
        }
    }
}
