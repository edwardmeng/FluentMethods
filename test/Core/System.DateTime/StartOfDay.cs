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
        public void StartOfDay()
        {
            DateTime @this = DateTime.Now;
            DateTime value = @this.StartOfDay(); // value = "yyyy/MM/dd 00:00:00:000";
            Assert.Equal(new DateTime(value.Year, value.Month, value.Day), value);
        }
    }
}
